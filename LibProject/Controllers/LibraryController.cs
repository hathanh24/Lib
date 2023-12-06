using LibProject.Models;
using LibProject.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        ILibraryRepository libraryRepository;
        public LibraryController(ILibraryRepository _libraryRepository)
        {
            libraryRepository = _libraryRepository;
        }
        [HttpPost]
        [Route("AddSach")]
        public async Task<IActionResult> AddSach([FromBody] Sach sach)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var sachId = await libraryRepository.AddSach(sach);
                    if (sachId > 0)
                    {
                        return Ok(sachId);

                    }
                    else return NotFound();

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest();
        }
        [HttpPost]
        [Route("AddTTV")]
        public async Task<IActionResult> AddTTV([FromBody] TheThuVien theThuVien)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var TTVId = await libraryRepository.AddTTV(theThuVien);
                    if (TTVId > 0)
                    {
                        return Ok(TTVId);

                    }
                    else return NotFound();

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest();
        }
        [HttpPost]
        [Route("DeleteSach/{sachId}")]
        public async Task<IActionResult> DeleteSach(int? sachId)
        {
            int result = 0;
            if (sachId == null)
            {
                return BadRequest();
            }
            try
            {
                result = await libraryRepository.DeleteSachById(sachId);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch { return BadRequest(); }
        }

        [HttpPost]
        [Route("DeleteTTV/{Id}")]
        public async Task<IActionResult> DeleteTTV(int? Id)
        {
            int result = 0;
            if (Id == null)
            {
                return BadRequest();
            }
            try
            {
                result = await libraryRepository.DeleteTTVById(Id);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch { return BadRequest(); }
        }

        [HttpPost]
        [Route("UpdateSach")]
        public async Task<IActionResult> UpdateSach([FromBody] Sach sach)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await libraryRepository.UpdateSach(sach);
                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }
            return BadRequest();
        }
        [HttpPost]
        [Route("SignUp")]
        public async Task<IActionResult> SignUp([FromBody] Account account)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var accountID = await libraryRepository.SignUp(account);
                    if (accountID > 0)
                    {
                        return Ok(accountID);
                    }
                    else return NotFound("Khong them duoc");
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest(ModelState);
        }
        [HttpGet]
        [Route("SignIn")]
        public async Task<IActionResult> SignIn()
        {
            try
            {
                var accounts = await libraryRepository.SignIn();
                if (accounts != null)
                {
                    return Ok(accounts);
                }
                return NotFound("Không thấy tài khoản nào!");
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("GetTTV")]
        public async Task<IActionResult> GetTTV()
        {
            try
            {
                var TTV = await libraryRepository.GetTTV();
                if (TTV != null)
                {
                    return Ok(TTV);
                }
                return NotFound();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("GetSach")]
        public async Task<IActionResult> GetSach()
        {
            try
            {
                var sach = await libraryRepository.GetSach();
                if (sach == null) return NotFound();
                return Ok(sach);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
