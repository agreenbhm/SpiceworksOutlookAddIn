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

        public static Outlook.MailItem GetMailItem(RibbonControlEventArgs e)
        {
            // Check to see if an item is selected in explorer or we are in inspector.
            if (e.Control.Context is Outlook.Inspector)
            {
                Outlook.Inspector inspector = (Outlook.Inspector)e.Control.Context;

                if (inspector.CurrentItem is Outlook.MailItem)
                {
                    return inspector.CurrentItem as Outlook.MailItem;
                }
            }

            if (e.Control.Context is Outlook.Explorer)
            {
                Outlook.Explorer explorer = (Outlook.Explorer)e.Control.Context;

                Outlook.Selection selectedItems = explorer.Selection;
                if (selectedItems.Count != 1)
                {
                    return null;
                }

                if (selectedItems[1] is Outlook.MailItem)
                {
                    return selectedItems[1] as Outlook.MailItem;
                }
            }

            return null;
        }

        public static void ForwardMessage(Outlook.MailItem mailItem)
        {
            if (mailItem != null)
            {
                string recipient = Properties.Settings.Default.HelpdeskEmail;
                if (recipient == "" || recipient == null)
                {
                    MessageBox.Show("Unable to forward message to Spiceworks; Please check that 'Helpdesk Email' is set in Settings"
                        , "Spiceworks: Error Forwarding", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    try
                    {
                        Outlook.MailItem newMsg = mailItem.Forward();
                        newMsg.Subject = mailItem.Subject;
                        newMsg.Body += "#created by " + GetSenderSMTPAddress(mailItem);

                        //newMsg.Recipients.Add("itsupport@tjtpa.com");
                        newMsg.Recipients.Add(recipient);
                        newMsg.Send();
                    }
                    catch
                    {
                        MessageBox.Show("Unable to forward message to Spiceworks; Please check that 'Helpdesk Email' is set in Settings"
                        , "Spiceworks: Error Forwarding", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }
    }
}
