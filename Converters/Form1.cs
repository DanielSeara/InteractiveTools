using System.Text;

namespace Converters;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void btnUTF8Enc_Click(object sender, EventArgs e)
    {
        //txtResultado.Text = Encoding.UTF8.GetBytes(txtSource.Text);
    }

    private void button2_Click(object sender, EventArgs e)
    {
        frmImportCSV frmImport = new frmImportCSV();
        frmImport.ShowDialog();
    }

    private void button3_Click(object sender, EventArgs e)
    {
        frmGenCrops frmGenCrops = new frmGenCrops();
        frmGenCrops.ShowDialog();
    }

    private void button4_Click(object sender, EventArgs e)
    {
        frmGenCurrencies frmGenCurrencies = new frmGenCurrencies();
        frmGenCurrencies.ShowDialog();

    }

    private void button5_Click(object sender, EventArgs e)
    {
        frmGenCustomers frmGenCustomers = new frmGenCustomers();
        frmGenCustomers.ShowDialog();
    }
}
