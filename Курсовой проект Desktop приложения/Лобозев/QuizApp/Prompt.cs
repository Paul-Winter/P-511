using System.Drawing;
using System.Windows.Forms;

public static class Prompt
{
    public static string ShowDialog(string text, string caption)
    {
        Form form = new Form();
        form.Width = 320;
        form.Height = 150;
        form.Text = caption;
        form.StartPosition = FormStartPosition.CenterParent;
        form.FormBorderStyle = FormBorderStyle.FixedDialog;
        form.MaximizeBox = false;
        form.MinimizeBox = false;

        Label label = new Label();
        label.Left = 10; label.Top = 15; label.Text = text; label.Width = 280;

        TextBox box = new TextBox();
        box.Left = 10; box.Top = 40; box.Width = 280;

        Button ok = new Button();
        ok.Text = "OK"; ok.Left = 200; ok.Width = 90; ok.Top = 75;
        ok.DialogResult = DialogResult.OK;

        form.Controls.Add(label);
        form.Controls.Add(box);
        form.Controls.Add(ok);
        form.AcceptButton = ok;

        return form.ShowDialog() == DialogResult.OK ? box.Text : "";
    }
}