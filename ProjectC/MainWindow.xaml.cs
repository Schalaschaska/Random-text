using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace ProjectC
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }
        public long n, index;//индексы количества рандомных букв и индекс рандомного массива
        public string m, open_m, str_p;//переменные для вывода и сохранения
        public bool flag = false;//основная задача генерации
        public bool flag_k, flag_l, save_flag, file_flag, file_flag_t, pr_gen_t, save_pr_t;//флаги условий кодировки, сохранения, сохранение файла, активации файла, активации генерации предложений
        public string pwdChars;//запись рандома букв
        public string[] mass_2;//промежуточный массив для рандома из файла
        private void ex_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void help_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Генерация псевдотекста \n \t2016","Справка");
        }

        private void open_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg_O = new Microsoft.Win32.OpenFileDialog();
            dlg_O.Filter = "Text documents (.txt)|*.txt";
            Nullable<bool> result = dlg_O.ShowDialog();
            if (result == true)
            {


                string[] mass = File.ReadAllLines(dlg_O.FileName);

                for (int i = 0; i < mass.Length; i++)
                {
                    richTextBox.AppendText(mass[i] + "\n");

                }
                mass_2 = mass;

                // richTextBox.Document.Blocks.Clear();
                file_flag = true;
                label3.Content = "Генерация из файла";
            }

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            file_flag = false;
            flag_k = false;
            flag_l = false;
            pr_gen_t = false;
            label3.Content = "";
            label4.Content = "";
            if (new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd).Text.Length < 3)//провера на наличие текста в rtb

                MessageBox.Show("Невозможно очистить пустое поле", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);
            else

                richTextBox.Document.Blocks.Clear();
        }

        private void pr_gen_Click(object sender, RoutedEventArgs e)
        {
            pr_gen_t = true;
            flag = false;
            label3.Content = "Генерация предложений";
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.Filter = "Text documents (.txt)|*.txt";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                if (save_pr_t == true)
                {
                    File.WriteAllText(dlg.FileName, str_p);
                }
                else
                {
                    if (save_flag == true)
                    {

                        File.WriteAllText(dlg.FileName, open_m);

                    }
                    else
                    {
                        // MessageBox.Show("2");
                        File.WriteAllText(dlg.FileName, m);
                    }
                }


            }

        }
        private void gen_text_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("!");
        }
        private void kiril_text_Click(object sender, RoutedEventArgs e)
        {
            flag_k = true;
            flag_l = false;
            label4.Content = "Кириллица";
        }
        private void latin_text_Click(object sender, RoutedEventArgs e)
        {
            flag_l = true;
            flag_k = false;
            label4.Content = "Латиница";
        }
        private void logic_Click(object sender, RoutedEventArgs e)
        {
            pr_gen_t = false;
            flag = true;
            label3.Content = "Генерация текста";
        }
        private void button_Click(object sender, RoutedEventArgs e)

        {

            if (pr_gen_t == true)
            {
                richTextBox.Document.Blocks.Clear();
                str_p = "";
                string[] a1 = new string[10] { "Товарищ!", "С другой стороны ", "Равным образом ", "Не следует, однако, забыть, что ", "Таким образом ", "Повседневная практика показыват, что ", "Значимость этих проблем настолько очевидная, что ", "Разнообразный и богатый опыт ", "Задача организации, в особенности же ", "Идейные соображения высокого порядка, а также " };
                string[] a2 = new string[10] { "реализация намеченных плановых заданий ", "рамки и место обучения кадров ", "постоянный количественный рост и сфера нашей активности ", "сложившаеся структура организации ", "новая модель организационной деятельности ", "дальнейшее развитие различных форм деятельности ", "постоянное информационно-пропагандисткое обеспечение нашей деятельности ", "управление и развитие структуры ", "консультация с широким активом ", "начало повседневной работы по формированию позиции" };
                string[] a3 = new string[10] { "играет важную роль в формировании ", "требует от наз анализа ", "требует определения и уточнения ", "способствует подготовке и реализации ", "обеспечивает широкому кругу ", "участие в формировании ", "в значительной степени обуславливает создание ", "позволяет оценить значение, представляет собой интересный эксперимент ", "позволяет выполнять разные задачи ", "проверки влечет за собой интересный процесс внедрения и модернизации" };
                string[] a4 = new string[10] { "существующим финансовых и административных условий.", "дальнейших направлений развития.", "системы массового участия.", "позиций, занимаемых участниками в отношении поставленных задач.", "новых предложений.", "направлений прогрессивного развития.", "системы обучения кадров, соответствующей насущным потребностям.", "соответствующих условий активизации.", "модели развития.", "форм воздействия." };
                Random r = new Random();
                str_p = (a1[r.Next(a1.Length)]) + (a2[r.Next(a2.Length)]) + (a3[r.Next(a3.Length)]) + (a4[r.Next(a4.Length)]);
                richTextBox.AppendText(str_p);
                save_pr_t = true;
            }
            else
            {
                if (file_flag == true)
                {
                    open_m = "";
                    // MessageBox.Show("!");
                    richTextBox.Document.Blocks.Clear();
                    Random rnd = new Random();
                    for (int index = 0; index < mass_2.Length; index++)
                    {
                        index = rnd.Next(0, mass_2.Length);

                        open_m += mass_2[index] + " ";


                        //MessageBox.Show(open_m);
                    }
                    richTextBox.AppendText(open_m + " ");
                    flag_k = false;
                    flag_l = false;
                    save_flag = true;

                }
                else
                {
                    if (flag == false)
                    {
                        richTextBox.Document.Blocks.Clear();
                        random_text Obj = new random_text();
                        richTextBox.AppendText(Obj.return_rand_rext());

                    }
                    else
                    {
                        if (textBox.Text == "")
                        {
                            MessageBox.Show("Ничего не введено!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {

                            try
                            {
                                if (flag_l == true)
                                {

                                    file_flag = false;
                                    m = "";
                                    richTextBox.Document.Blocks.Clear();
                                    n = Convert.ToInt32(textBox.Text);
                                    Random mass = new Random();

                                    Char[] pwdChars = new Char[27] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', ' ' };

                                    for (int i = 0; i < n; i++)
                                        m += pwdChars[mass.Next(0, 27)];
                                    richTextBox.AppendText(m);

                                }
                                if (flag_k == true)
                                {
                                    file_flag = false;
                                    m = "";
                                    richTextBox.Document.Blocks.Clear();
                                    n = Convert.ToInt32(textBox.Text);
                                    Random mass = new Random();
                                    Char[] pwdChars = new Char[33] { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ц', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я', ' ' };
                                    for (int i = 0; i < n; i++)
                                        m += pwdChars[mass.Next(0, 27)];
                                    richTextBox.AppendText(m);
                                }

                            }
                            catch (System.FormatException)
                            {
                                MessageBox.Show("Некорректнй ввод", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);



                            }

                        }
                    }
                }
            }
        }
    }
}
