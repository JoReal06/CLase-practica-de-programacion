using System.Web;

namespace Ejercicio_1
{
    public partial class Form1 : Form
    {
        public Reader re = new Reader();
        public Writer wri = new Writer();
        private List<StreamWriter> nuevos = new List<StreamWriter>();
        public Form1()
        {
            InitializeComponent();
        }

        private async void btn_director_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            await Proceso();
            pictureBox1.Visible = false;
            MessageBox.Show("se sobreescribio los archivos txt a letra mayuscula");





        }

        async Task Proceso()
        {
            using (OpenFileDialog open_dialog = new OpenFileDialog())
            {
                open_dialog.Filter = "Archivos de Texto|*.txt|todos los archivos|*.*";
                open_dialog.Multiselect = true;

                if (open_dialog.ShowDialog() == DialogResult.OK)
                { 
                    foreach (string paths in open_dialog.FileNames)
                    {
                        string texto_original = await Leer(paths, re);
                        nuevos.Add(await Escribir(paths, wri, texto_original));
                    }

                    int cantidad_de_archivos = open_dialog.FileNames.Length;
                    MessageBox.Show($"se leyeron {cantidad_de_archivos} archivos a su totalidad");
                    
                }
                else
                {
                    return;
                }
            }

            

        }

        async Task<string> Leer(string paths, Reader re)
        {
            return (string)await re.Aux(paths,"");
        }

        async Task<StreamWriter> Escribir(string paths, Writer wri,string text_original)
        {
            return (StreamWriter)await wri.Aux(paths, text_original);

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
        }
    }
}

