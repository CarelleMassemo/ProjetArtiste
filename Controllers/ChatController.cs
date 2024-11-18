using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetArtiste1.Data;
using ProjetArtiste1.Models;

namespace ProjetArtiste1.Controllers
{
    public class ChatController : Controller
    {
        public readonly ApplicationDbContext _context;
        public readonly UserManager<ApplicationUser> _userManager;

        public ChatController( ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.CurrentUserName = currentUser.UserName;
            }
            var Message = await _context.Messages.ToListAsync();
            return View();
        }

        public async Task<IActionResult> Create (Message message)
        {
            if(ModelState .IsValid)
            {
                message.UserName = User.Identity.Name;
                 var sender = await _userManager.GetUserAsync(User);
                message.UserID = sender.Id;
                await _context.Messages.AddAsync(message);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return View();
        }
            
    }
}
