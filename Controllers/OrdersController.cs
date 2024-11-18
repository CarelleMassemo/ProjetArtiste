using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetArtiste1.Data.Cart;
using ProjetArtiste1.Data.Services;
using ProjetArtiste1.Data.ViewModels;
using ProjetArtiste1.Models;
using System.Security.Claims;

namespace ProjetArtiste1.Controllers
{
   
    public class OrdersController : Controller
    {
        
        private readonly Commande _commande;
        private readonly IOrdersService _ordersService;
        private readonly IOeuvresService _oeuvresService;
      

        public OrdersController(Commande commande, IOrdersService ordersService, IOeuvresService oeuvresService)
        {
            _commande = commande;
            _ordersService = ordersService;
            _oeuvresService = oeuvresService;

        }

        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userRole = User.FindFirstValue(ClaimTypes.Role);

            var orders = await _ordersService.GetOrdersByUserIdAndRoleAsync(userId, userRole);
            return View(orders);
        }
      
        public IActionResult ShoppingCart()
        {
            var items = _commande.GetShoppingCartItems();
            _commande.LigneCommandes = items;

            var response = new CommandeVM()
            {
                commande = _commande,
                ShoppingCartTotal = _commande.GetShoppingCartTotal()
            };

            return View(response);
        }
        [Authorize]
        public async Task<IActionResult> AddItemToShoppingCart(int id)
        {
            var item = await _oeuvresService.GetOeuvreByIdAsync(id);

            if (item != null)
            {
                _commande.AddItemToCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
        {
            var item = await _oeuvresService.GetOeuvreByIdAsync(id);

            if (item != null)
            {
                _commande.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<IActionResult> CompleteOrder()
        {
            var items = _commande.GetShoppingCartItems();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userEmailAddress = User.FindFirstValue(ClaimTypes.Email);

            await _ordersService.StoreOrderAsync(items, userId, userEmailAddress);
            await _commande.ClearShoppingCartAsync();

            return View("OrderCompleted");
        }
    }
}

