using BLL.Abstract;
using CORE;
using DAL.Abrtract;
using System.Net.Mail;
using System.Text;

namespace BLL.Concrete
{
    public class MailManager: IMailManager
    {
        private readonly IMovieDAL movieDAL;
        private readonly HostMail hostMail;
        public MailManager(IRepository<Movie> repository, HostMail hostMail)
        {
            this.movieDAL = (IMovieDAL)repository;
            this.hostMail = hostMail;   
        }

        public bool Recommend(RecommendMail recommendMail)
        {
            Movie movie = movieDAL.Get(recommendMail.MovieId);

            MailMessage message = CreateMessage(recommendMail.MailAddress, movie);
            return MailSend(hostMail.Port, hostMail.HostMailServer, hostMail.SenderMail, hostMail.SenderPassword, message); ;
        }

        private MailMessage CreateMessage(string ToMail, Movie movie)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("<h1>I recommend you a movie</h1>");
            stringBuilder.AppendLine(string.Format("<h5>{0}<h5>", movie.Title));

            MailMessage message = new MailMessage();
            message.Subject = "I recommend you a movie.";
            message.Body = stringBuilder.ToString();
            message.To.Add(ToMail);
            message.IsBodyHtml = true;
            message.From = new MailAddress(hostMail.SenderMail);

            return message;
        }

        private bool MailSend(int Port, string HostMailServer, string SenderMail, string SenderPassword, MailMessage Message)
        {
            try
            {
                SmtpClient client = new SmtpClient();
                client.Port = Port;
                client.Host = HostMailServer;
                client.EnableSsl = true;
                client.Credentials = new System.Net.NetworkCredential(SenderMail, SenderPassword);
                client.Send(Message);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
