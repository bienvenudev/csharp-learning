using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CipherServices.Services;
using CipherServices.Data;
using CipherServices.Models;

namespace CipherServices.Pages
{
  // Annotation Required for Codecademy Workspace
  // For proper POST Behavior
  [IgnoreAntiforgeryToken(Order = 1001)]
  public class IndexModel : PageModel
  {
    public Dictionary<string, string> Secrets { get; set; }
    [BindProperty]
    public Message NewMessage { get; set; }
    private readonly MessageContext _context;
    private readonly IDecrypter _decrypter;
    private readonly IEncrypter _encrypter;

    public IndexModel(MessageContext context, IDecrypter decrypter, IEncrypter encrypter)
    {
      // is it at this point that the framework creates the object to inject or I'm missing something?
      _context = context;
      _decrypter = decrypter;
      _encrypter = encrypter;
    }

    public async Task<IActionResult> OnPostAsync()
    {
      if (ModelState.IsValid)
      {
        var cleanMessage = NewMessage.Text.Trim().ToLower();
        string encryptedText = _encrypter.Encrypt(cleanMessage); // does this assume that the framework already created an object of _encrypter? and it just injects it or what?
        Message message = new Message { Text = encryptedText };
        _context.Messages.Add(message);
        await _context.SaveChangesAsync();
        return RedirectToPage("/Index");
      }
      else
      {
        await LoadSecretsAsync(_decrypter, _context);
        return Page();
      }
    }

    public async Task<IActionResult> OnGetAsync()
    {
      await LoadSecretsAsync(_decrypter, _context);
      return Page(); // what is page??!
    }

    private async Task LoadSecretsAsync(IDecrypter decrypter, MessageContext context)
    {
      Secrets = new Dictionary<string, string>();
      var messages = await context.Messages.ToListAsync();

      foreach (Message m in messages)
      {
        Secrets.TryAdd(m.Text, decrypter.Decrypt(m.Text));
      }
    }
  }
}
