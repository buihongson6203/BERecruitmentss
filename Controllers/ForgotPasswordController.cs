using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BERecruitmentss.Services;
using System;
using System.Threading.Tasks;

namespace BERecruitmentss.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForgotPasswordController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly UserManager<IdentityUser> _userManager;

        public ForgotPasswordController(UserManager<IdentityUser> userManager, IEmailService emailService)
        {
            _userManager = userManager;
            _emailService = emailService;
        }

        [HttpPost("forgotpassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordModel model)
        {
            string email = model.Email;
            // Kiểm tra xem email có tồn tại trong cơ sở dữ liệu không
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                // Log lỗi ở đây
                Console.WriteLine($"Không thể tìm thấy người dùng với email: {email}");
                return BadRequest(new { message = "Email không tồn tại." });
            }

            // Tạo resetToken và mã ngẫu nhiên
            string resetToken = GenerateResetToken();
            string code = GenerateRandomCode();
            string emailContent = $"Mã xác nhận của bạn là: <strong>{code}</strong>";

            // Địa chỉ email gốc để gửi email
            string fromEmail = "your_email@gmail.com"; // Thay đổi email của bạn tại đây
            string callbackUrl = $"https://yourwebsite.com/resetpassword?token={resetToken}&email={model.Email}";
            string emailSubject = "Reset Password for " + model.Email;

            // Mã hóa mật khẩu tạm thời
            var passwordHash = new PasswordHasher<IdentityUser>().HashPassword(user, code);
            user.PasswordHash = passwordHash;

            // Cập nhật mật khẩu cho tài khoản
            await _userManager.UpdateAsync(user);

            // Gửi email
            await _emailService.SendEmailAsync(fromEmail, model.Email, emailSubject, emailContent);

            return Ok(new { message = "Email reset password đã được gửi." });
        }

        [HttpPost("confirmcode")]
        public async Task<IActionResult> ConfirmCode([FromBody] ConfirmCodeModel model)
        {
            string email = model.Email;
            string code = model.Code;

            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                Console.WriteLine($"Không thể tìm thấy người dùng với email: {email}");
                return BadRequest(new { message = "Email không tồn tại." });
            }

            // Kiểm tra mã code nhập vào có trùng khớp với mã code đã lưu trong cơ sở dữ liệu hay không
            var passwordHasher = new PasswordHasher<IdentityUser>();
            var result = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, code);

            if (result != PasswordVerificationResult.Success)
            {
                Console.WriteLine($"Mã code không hợp lệ cho email: {email}");
                return BadRequest(new { message = "Mã code không hợp lệ." });
            }

            // Xóa mật khẩu tạm thời
            user.PasswordHash = null;
            await _userManager.UpdateAsync(user);

            return Ok(new { message = "Xác nhận mã code thành công." });
        }


        public class ConfirmCodeModel
        {
            public string Email { get; set; }
            public string Code { get; set; }
        }

        [HttpPost("resetpassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                Console.WriteLine($"Không thể tìm thấy người dùng với email: {model.Email}");
                return BadRequest(new { message = "Email không tồn tại." });
            }

            // Đặt lại mật khẩu mới cho người dùng
            var newPasswordHash = new PasswordHasher<IdentityUser>().HashPassword(user, model.NewPassword);
            user.PasswordHash = newPasswordHash;

            // Cập nhật mật khẩu cho tài khoản
            await _userManager.UpdateAsync(user);

            return Ok(new { message = "Đặt lại mật khẩu thành công." });
        }

        public class ResetPasswordModel
        {
            public string Email { get; set; }
            public string NewPassword { get; set; }
        }



        private string GenerateResetToken()
        {
            // Tạo và trả về resetToken, sử dụng Guid
            return Guid.NewGuid().ToString();
        }

        public class ForgotPasswordModel
        {
            public string Email { get; set; }
        }
        private string GenerateRandomCode()
        {
            Random random = new Random();
            int code = random.Next(100000, 999999); // Sinh số ngẫu nhiên từ 100,000 đến 999,999
            return code.ToString();
        }

    }
}
