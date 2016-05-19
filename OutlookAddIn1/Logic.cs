using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using System.Windows.Forms;
using System.Drawing;

namespace OutlookAddIn1
{
    class Logic
    {
        public static string GetSenderSMTPAddress(Outlook.MailItem mail)
        {
            string PR_SMTP_ADDRESS =
                @"http://schemas.microsoft.com/mapi/proptag/0x39FE001E";
            if (mail == null)
            {
                throw new ArgumentNullException();
            }
            if (mail.SenderEmailType == "EX")
            {
                Outlook.AddressEntry sender =
                    mail.Sender;
                if (sender != null)
                {
                    //Now we have an AddressEntry representing the Sender
                    if (sender.AddressEntryUserType ==
                        Outlook.OlAddressEntryUserType.
                        olExchangeUserAddressEntry
                        || sender.AddressEntryUserType ==
                        Outlook.OlAddressEntryUserType.
                        olExchangeRemoteUserAddressEntry)
                    {
                        //Use the ExchangeUser object PrimarySMTPAddress
                        Outlook.ExchangeUser exchUser =
                            sender.GetExchangeUser();
                        if (exchUser != null)
                        {
                            return exchUser.PrimarySmtpAddress;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        return sender.PropertyAccessor.GetProperty(
                            PR_SMTP_ADDRESS) as string;
                    }
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return mail.SenderEmailAddress;
            }
        }

        public static List<Outlook.MailItem> GetMailItem(RibbonControlEventArgs e)
        {
            List<Outlook.MailItem> returnList = new List<Outlook.MailItem>();
            // Check to see if an item is selected in explorer or we are in inspector.
            if (e.Control.Context is Outlook.Inspector)
            {
                Outlook.Inspector inspector = (Outlook.Inspector)e.Control.Context;

                if (inspector.CurrentItem is Outlook.MailItem)
                {
                    returnList.Add(inspector.CurrentItem as Outlook.MailItem);
                    //return inspector.CurrentItem as Outlook.MailItem;
                    return returnList;
                }
            }

            if (e.Control.Context is Outlook.Explorer)
            {
                Outlook.Explorer explorer = (Outlook.Explorer)e.Control.Context;

                Outlook.Selection selectedItems = explorer.Selection;
                if (selectedItems.Count == 0)
                {
                    return returnList;
                }
                else if(selectedItems.Count == 1)
                {
                    if (selectedItems[1] is Outlook.MailItem)
                    {
                        returnList.Add(selectedItems[1] as Outlook.MailItem);
                    }
                    return returnList;
                }
                else
                {
                    foreach(var item in selectedItems)
                    {
                        if(item is Outlook.MailItem)
                        {
                            returnList.Add(item as Outlook.MailItem);
                        }
                    }
                    return returnList;
                }
            }

            return returnList;
        }

        public static void ForwardMessage(Outlook.MailItem mailItem)
        {
            if (mailItem != null)
            {
                if (!Properties.Settings.Default.NoCloseConf)
                {
                    DialogResult confirm = MessageBox.Show("Create Ticket?\nSubject: " + mailItem.Subject,
                        "Spiceworks Outlook AddIn", MessageBoxButtons.YesNo);
                    if (confirm == DialogResult.Yes)
                    {
                        string recipient = Properties.Settings.Default.HelpdeskEmail;
                        if (recipient == "" || recipient == null)
                        {
                            MessageBox.Show("Unable to forward message to Spiceworks. Please check that 'Helpdesk Email' is set in Settings."
                                , "Spiceworks Outlook AddIn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            try
                            {
                                Outlook.MailItem newMsg = mailItem.Forward();
                                newMsg.Subject = mailItem.Subject;
                                newMsg.Body += "\n\n#created by " + Logic.GetSenderSMTPAddress(mailItem);
                                newMsg.Recipients.Add(recipient);
                                newMsg.Send();
                                if (Properties.Settings.Default.CloseMsg)
                                {
                                    mailItem.Close(Outlook.OlInspectorClose.olPromptForSave);
                                }
                            }
                            catch
                            {
                                MessageBox.Show("Unable to forward message to Spiceworks. Please check that 'Helpdesk Email' is set in Settings."
                                , "Spiceworks Outlook AddIn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                else
                {
                    string recipient = Properties.Settings.Default.HelpdeskEmail;
                    if (recipient == "" || recipient == null)
                    {
                        MessageBox.Show("Unable to forward message to Spiceworks. Please check that 'Helpdesk Email' is set in Settings."
                            , "Spiceworks Outlook AddIn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        try
                        {
                            Outlook.MailItem newMsg = mailItem.Forward();
                            newMsg.Subject = mailItem.Subject;
                            newMsg.Body += "\n\n#created by " + Logic.GetSenderSMTPAddress(mailItem);
                            newMsg.Recipients.Add(recipient);
                            newMsg.Send();
                            if (Properties.Settings.Default.CloseMsg)
                            {
                                mailItem.Close(Outlook.OlInspectorClose.olPromptForSave);
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Unable to forward message to Spiceworks. Please check that 'Helpdesk Email' is set in Settings."
                            , "Spiceworks Outlook AddIn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        public static void CloseTicket(Outlook.MailItem mailItem)
        {
            if (mailItem != null)
            {
                if (!Properties.Settings.Default.NoCloseConf)
                {
                    DialogResult confirm = MessageBox.Show("Close Ticket?\nSubject: " + mailItem.Subject,
                        "Spiceworks Outlook AddIn", MessageBoxButtons.YesNo);
                    if (confirm == DialogResult.Yes)
                    {
                        try
                        {
                            Outlook.MailItem newMsg = mailItem.Reply();
                            newMsg.Body = "#close";
                            newMsg.Send();
                            if (Properties.Settings.Default.CloseMsg)
                            {
                                mailItem.Close(Outlook.OlInspectorClose.olPromptForSave);
                            }
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("Unable to close ticket. Error: " + e.ToString()
                                , "Spiceworks Outlook AddIn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    try
                    {
                        Outlook.MailItem newMsg = mailItem.Reply();
                        newMsg.Body = "#close";
                        newMsg.Send();
                        if (Properties.Settings.Default.CloseMsg)
                        {
                            mailItem.Close(Outlook.OlInspectorClose.olPromptForSave);
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Unable to close ticket. Error: " + e.ToString()
                            , "Spiceworks Outlook AddIn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                
            }
        }

        public static void CloseTicketWithResponse(Outlook.MailItem mailItem)
        {
            if (mailItem != null)
            {
                try
                {
                    Outlook.MailItem newMsg = mailItem.Reply();
                    newMsg.Body = "\n\n#close" + newMsg.Body;
                    newMsg.Display();
                    if (Properties.Settings.Default.CloseMsg)
                    {
                        mailItem.Close(Outlook.OlInspectorClose.olPromptForSave);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Unable to close ticket. Error: " + e.ToString()
                        , "Spiceworks Outlook Addin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public static void AssignTicket(Outlook.MailItem mailItem, string email)
        {
            if (mailItem != null)
            {
                if (!Properties.Settings.Default.NoAssignConf)
                {
                    DialogResult confirm = MessageBox.Show("Assign Ticket to " + email + 
                        "?\nSubject: " + mailItem.Subject, "Spiceworks Outlook AddIn", MessageBoxButtons.YesNo);
                    if (confirm == DialogResult.Yes)
                    {
                        try
                        {
                            Outlook.MailItem newMsg = mailItem.Reply();
                            newMsg.Body = "#assign to " + email;
                            newMsg.Send();
                            if (Properties.Settings.Default.CloseMsg)
                            {
                                mailItem.Close(Outlook.OlInspectorClose.olPromptForSave);
                            }
                            
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("Unable to assign ticket. Error: " + e.ToString()
                                , "Spiceworks Outlook AddIn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    try
                    {
                        Outlook.MailItem newMsg = mailItem.Reply();
                        newMsg.Body = "#assign to " + email;
                        newMsg.Send();
                        if (Properties.Settings.Default.CloseMsg)
                        {
                            mailItem.Close(Outlook.OlInspectorClose.olPromptForSave);
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Unable to assign ticket. Error: " + e.ToString()
                            , "Spiceworks Outlook AddIn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
        }

    }
}
