using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber
{
    public delegate void Notificationhandler (string message);
    public class Subscriber : Colors
    {
        public event Notificationhandler OnNotification;
        public void Notification (string message)
        {
            if (OnNotification != null)
            {
                OnNotification (message);
            }
            else
            {
                RED ();
                Console.WriteLine ("You Have No Subscribers:(");
                WHITE ();
            }
        }
    }
    public class User : Colors
    {
        public string Name { get; set; }
        public List<string> Message = new List<string> ();
        void Separate ()
        {
            Console.WriteLine ("=============== - ================ - ==================");
        }
        public void ReceiveNotification (string message)
        {
            Message.Add (message);
            BLUE ();
            Console.WriteLine ($"Message Sent For {Name} From : {message}.");
            WHITE ();
            Separate ();
        }
        public void AlreadyExist ()
        {
            RED ();
            Console.WriteLine ("This Username Is Already Taken.");
            WHITE ();
            Separate ();
        }
        public void NotFound ()
        {
            RED ();
            Console.WriteLine ("Your Username Not Found | Or You May Be Unsubscribed Already.");
            WHITE ();
            Separate ();
        }
        public void NoSubscribers ()
        {
            RED ();
            Console.WriteLine ("There Are No Subscribers:(");
            WHITE ();
            Separate ();
        }
        public void Subscribe ()
        {
            GREEN ();
            Console.WriteLine ($"{Name} Subscribed Successfully!");
            WHITE ();
        }
        public void Unsubscribe ()
        {
            RED ();
            Console.WriteLine ($"{Name} Unsubscribed Successfully");
            WHITE ();
        }
        public void SeeNotifications ()
        {
            if (Message.Count != 0)
            {
                Separate ();
                BLUE ();
                Console.WriteLine ("Your Inbox:");
                WHITE ();
                for (int i = 0; i < Message.Count; i++)
                {
                    Console.WriteLine (Message[i]);
                }
                Separate ();
            }
            else
            {
                Separate ();
                RED ();
                Console.WriteLine ("You Have No Notifications :(");
                WHITE ();
                Separate ();
            }
        }
    }
    public class Colors
    {
        public void RED ()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        public void GREEN ()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        public void BLUE ()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
        }
        public void WHITE ()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}