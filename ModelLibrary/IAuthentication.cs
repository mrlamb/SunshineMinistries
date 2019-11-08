using System.Threading.Tasks;
using ModelLibrary.Models;

namespace ModelLibrary
{
    public interface IAuthentication
    {
        UserCredentials Authenticate(string userName , string userPassword);
    }
}