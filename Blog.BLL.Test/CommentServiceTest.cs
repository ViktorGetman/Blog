using AutoMapper;
using Blog.BLL.Models;
using Blog.BLL.Services;
using Blog.DAL;
using Blog.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Moq;
using Xunit;

namespace Blog.BLL.Test
{
    public class CommentServiceTests
    {
        [Fact]
        public async Task AddComment_ShouldAddCommentToDatabase()
        {
            // Arrange
            var mockDbContextFactory = new Mock<DbContext<DbContextOptionsBuilder>>(); // Замените на фактический тип вашего DbContext
            var mockMapper = new Mock<IMapper>();
            var commentService = new CommentService(mockDbContextFactory.Object, mockMapper.Object);

            var postId = 1;
            var userId = 1;
            var commentModel = new CommentModel { PostId = postId, Content = "Test Comment", UserId = userId};
            var comment = new CommentEntity { PostId = postId, Content = "Test Comment", UserId = userId };

            mockMapper.Setup(m => m.Map<CommentEntity>(commentModel)).Returns(comment);

            // Эмулируем создание DbContext через IContextFactory
            var mockDbContext = new Mock<BlogDbContext>();
            mockDbContextFactory.Setup(x => x.CreateDbContextAsync(CancellationToken.None)).ReturnsAsync(mockDbContext.Object);

            // Act
            await commentService.Create(commentModel);

            // Assert
            mockDbContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        // Добавьте аналогичные тесты для других методов (чтение, редактирование, удаление)...
    }
}
