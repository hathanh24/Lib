using LibProject.Models;
using Microsoft.EntityFrameworkCore;

namespace LibProject.Repository
{
    public class LibraryRepository : ILibraryRepository
    {
        LibraryDbContext db;
        public LibraryRepository(LibraryDbContext _db)
        {
            db = _db;
        }
        public async Task<List<Sach>> GetSach()
        {
            if (db != null)
            {
                return await (from s in db.Saches
                              select new Sach
                              {
                                  Id = s.Id,
                                  TenSach = s.TenSach,
                                  TacGia = s.TacGia,
                                  NhaXuatBan = s.NhaXuatBan,
                                  SoLuong = s.SoLuong
                              }).ToListAsync();
            }
            return null;
        }

        public async Task<int> AddSach(Sach sach)
        {
            if (db != null)
            {
                await db.Saches.AddAsync(sach);
                await db.SaveChangesAsync();
                return sach.Id;
            }
            return 0;
        }
        public async Task<int> DeleteSachById(int? Id)
        {
            int result = 0;
            if (db != null)
            {
                var sach = await db.Saches.FirstOrDefaultAsync(x => x.Id == Id);
                if (sach != null)
                {
                    db.Saches.Remove(sach);
                    result = await db.SaveChangesAsync();
                }
                return result;
            }
            return result;
        }
        public async Task UpdateSach(Sach sach)
        {
            if (db != null)
            {
                db.Saches.Update(sach);
                await db.SaveChangesAsync();
            }
        }
        public async Task<int> SignUp(Account account)
        {
            if (db != null)
            {
                await db.Accounts.AddAsync(account);
                await db.SaveChangesAsync();
                return account.Id;
            }
            return 0;
        }
        public async Task<List<Account>> SignIn()
        {
            if (db != null)
            {
                return await (from account in db.Accounts
                              select new Account
                              {
                                  UserName = account.UserName,
                                  Gmail = account.Gmail,
                                  Password = account.Password
                              }).ToListAsync();
            }
            return null;
        }
        public async Task<int> AddTTV(TheThuVien theThuVien)
        {
            if (db != null)
            {
                await db.TheThuViens.AddAsync(theThuVien);
                await db.SaveChangesAsync();
                return theThuVien.Id;
            }
            return 0;
        }
        public async Task<List<TheThuVien>> GetTTV()
        {
            if (db != null)
            {
                return await (from ttv in db.TheThuViens
                              select new TheThuVien
                              {
                                  Id = ttv.Id,
                                  HoVaTen = ttv.HoVaTen,
                                  Email = ttv.Email,
                                  SoDienThoai = ttv.SoDienThoai,
                                  DiaChi = ttv.DiaChi,
                                  NgaySinh = ttv.NgaySinh,
                                  GioiTinh = ttv.GioiTinh
                              }).ToListAsync();
            }
            return null;
        }
        public async Task<int> DeleteTTVById(int? Id)
        {
            int result = 0;
            if (db != null)
            {
                var TTV = await db.TheThuViens.FirstOrDefaultAsync(x => x.Id == Id);
                if (TTV != null)
                {
                    db.TheThuViens.Remove(TTV);
                    result = await db.SaveChangesAsync();
                }
                return result;
            }
            return result;
        }


    }
}
