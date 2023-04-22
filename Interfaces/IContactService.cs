namespace AIMGSM.Interfaces
{
    public interface IContactService
    {
        void SendEmail(string name, string email, string message);
    }
}
