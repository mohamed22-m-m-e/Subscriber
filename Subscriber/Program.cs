using Subscriber;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.Configuration;
using System.Reflection.Emit;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Subscriber 
{
    public class Program
    {
        static void Main (string[] args)
        {
            Subscriber subscriber = new Subscriber();
            User user = new User ();
            List<User> list = new List<User> ();
            while (true)
            {
                Console.WriteLine ("1.Subscribe  -  2.Send Notification   -   3.View Notifications  -   4.Unsubscribe   -   5.Shut Down");
                Console.Write ("Action: ");
                int answer = int.Parse (Console.ReadLine ());
                switch (answer)
                {
                    case 1:
                        Console.Write ("Enter your Username: ");
                        string user_name = Console.ReadLine ();
                        int i = 0;
                        do
                        {
                            if (list.Count == 0)
                            {
                                user.Name = user_name;
                                list.Add (user);
                                subscriber.OnNotification += list[i].ReceiveNotification;
                                list[i].Subscribe ();
                                break;
                            }
                            else if (list[i].Name.Equals (user_name, StringComparison.OrdinalIgnoreCase) == true)
                            {
                                user.AlreadyExist ();
                                i++;
                                break;
                            }
                            else if (list.Count - 1 == i)
                            {
                                list.Add (new User () { Name = user_name });
                                subscriber.OnNotification += list[i += 1].ReceiveNotification;
                                list[i].Subscribe ();
                                break;
                            }
                            i++;
                        } while (i < list.Count);
                        break;
                    case 2:
                        Console.Write ("Send The Message: ");
                        string message = Console.ReadLine ();
                        subscriber.Notification (message);
                        break;
                    case 3:
                        if (list.Count != 0)
                        {
                            Console.Write ("Enter Your Username: ");
                            string Name = Console.ReadLine ();
                            for (i = 0; i < list.Count; i++)
                            {
                                if (list[i].Name.Equals (Name, StringComparison.OrdinalIgnoreCase) == true)
                                {
                                    list[i].SeeNotifications ();
                                    break;
                                }
                                else if (list.Count - 1 == i)
                                {
                                    user.RED ();
                                    Console.WriteLine ("Your Username Not Found");
                                    user.WHITE ();
                                    break;
                                }
                            }
                            break;
                        }
                        else
                        {
                            user.NoSubscribers ();
                            break;
                        }
                    case 4:
                        if (list.Count != 0)
                        {
                            Console.Write ("Please Enter Your Username: ");
                            string name = Console.ReadLine ();
                            {
                                for (i = 0; i < list.Count; i++)
                                {
                                    if (list[i].Name.Equals (name, StringComparison.OrdinalIgnoreCase) == true)
                                    {
                                        list[i].Unsubscribe ();
                                        subscriber.OnNotification -= list[i].ReceiveNotification;
                                        break;
                                    }
                                    else if (list.Count - 1 == i)
                                    {
                                        user.NotFound ();
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                        else
                        {
                            user.NoSubscribers ();
                            break;
                        }
                    case 5:
                        user.RED ();
                        Console.WriteLine ("Shutting Down...");
                        user.WHITE ();
                        return;
                }
            }
        }
    }
}
