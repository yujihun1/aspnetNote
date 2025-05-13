using aspnetNote.DataContext;
using aspnetNote.Models;
using aspnetNote.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace aspnetNote.Controllers
{
    public class AccountController : Controller
    {
        /// <summary>
        /// 로그인
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            //ID, 비밀번호 - 필수
            if (ModelState.IsValid)
            {
                using (var db = new AspnetNoteDbContext())
                {
                    //Linq - 메서드 체이닝
                    // => : A Go to B
                    var user = db.Users
                        .FirstOrDefault(u => u.UserId.Equals(model.UserId) &&
                                        u.UserPassword.Equals(model.UserPassword));
                    if (user != null)
                    {
                        //로그인 성공
                        return RedirectToAction("LoginSuccess", "Home"); //로그인 성공 페이지로 이동
                    }
                }
                //로그인 실패
                ModelState.AddModelError(string.Empty, "사용자 ID 혹은 비밀번호가 올바르지 않습니다.");
            }
            return View(model);
        }

        
        /// <summary>
        /// 회원가입
        /// </summary>
        /// <returns></returns>
        public IActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// 화원 가입 전송
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpPost]
        public IActionResult Register(User model)
        {
            if(ModelState.IsValid)
            {
                using(var db = new AspnetNoteDbContext())
                {
                    db.Users.Add(model);
                    db.SaveChanges();
                }
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}
