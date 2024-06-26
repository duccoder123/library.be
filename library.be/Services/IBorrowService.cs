namespace library.be.Services
{
    public interface IBorrowService
    {
        Task BorrowAsync(int bookId, int amount);
    }
}
