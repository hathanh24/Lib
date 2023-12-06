using LibProject.Models;

namespace LibProject.Repository
{
    public interface ILibraryRepository
    {
        Task<int> AddSach(Sach sach);
        Task<int> DeleteSachById(int? Id);
        Task UpdateSach(Sach sach);
        Task<int> SignUp(Account account);
        Task<List<Account>> SignIn();
        Task<List<Sach>> GetSach();
        Task<int> AddTTV(TheThuVien theThuVien);
        Task<List<TheThuVien>> GetTTV();
        Task<int> DeleteTTVById(int? Id);

        

    }
}
