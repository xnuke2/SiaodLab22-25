using System;
using System.Diagnostics;
using System.Reflection;
using System.Security.Cryptography;
using static SiaodLab22_25.Form1;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace SiaodLab22_25
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(5);
            dataGridView1.Rows[0].Cells[1].Value = "Простое 2Ф";
            dataGridView1.Rows[1].Cells[1].Value = "Простое 1Ф";
            dataGridView1.Rows[2].Cells[1].Value = "Естественное 2Ф";
            dataGridView1.Rows[3].Cells[1].Value = "Естественное 1Ф";
            dataGridView1.Rows[4].Cells[1].Value = "Поглощение";
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = true;
            }
        }
        public bool Check(int[] Array)
        {
            for (int i = 1; i < Array.Length; i++)
            {
                if (Array[i] < Array[i - 1])
                {
                    return false;
                }
            }
            return true;
        }

        rezult mergeSimple(int[] array)
        {
            rezult Rezalt = new rezult();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int n = array.Length;
            int mid = n / 2;
            if (n % 2 == 1)
                mid++;
            int[] A = new int[n];
            int[] B = new int[n];
            
            int SerLen = 1;
            while (SerLen/2 < array.Length) 
            {
                bool AB = true;
                int AInd = 0; int BInd = 0;
                int st = 0;
                while (st + SerLen < n)
                {                 
                    if (AB)
                    {
                        for (int j1 = st; j1 < st+SerLen; j1++)
                        {
                            Rezalt.reinstallation++;
                            A[AInd] = array[j1];
                            AInd++;
                        }
                        AB = false;
                    }
                    else
                    {
                        for (int j1 = st; j1 < st + SerLen; j1++)
                        {
                            Rezalt.reinstallation++;
                            B[BInd] = array[j1];
                            BInd++;
                        }
                        AB = true;
                    }
                    st = st + SerLen;

                } ;

                if (AB)
                {
                    for (int j1 = st; j1 < n; j1++)
                    {
                        Rezalt.reinstallation++;
                        A[AInd] = array[j1];
                        AInd++;
                    }
                }
                else
                {
                    for (int j1 = st; j1 < n; j1++)
                    {
                        Rezalt.reinstallation++;
                        B[BInd] = array[j1];
                        BInd++;
                    }
                }
                int step = SerLen;
                int Aindex = 0;
                int Bindex = 0;
                int Arrayindex = 0;
                while (step <=AInd&&step<=BInd)
                {
                    while ((Aindex < step) && (Bindex < step))
                    {
                        Rezalt.comparisons++;
                        if (A[Aindex] < B[Bindex])
                        {
                            Rezalt.reinstallation++;
                            array[Arrayindex] = A[Aindex];
                            Aindex++; Arrayindex++;
                        }
                        else
                        {
                            Rezalt.reinstallation++;
                            array[Arrayindex] = B[Bindex];
                            Bindex++; Arrayindex++;
                        }
                    }
                    while (Aindex < step)
                    {
                        Rezalt.reinstallation++;
                        array[Arrayindex] = A[Aindex];
                        Aindex++; Arrayindex++;
                    }
                    while (Bindex < step)
                    {
                        Rezalt.reinstallation++;
                        array[Arrayindex] = B[Bindex];
                        Bindex++; Arrayindex++;
                    }
                    step = step + SerLen; 
                }
                SerLen = SerLen * 2;
            }
            //SerLen = SerLen /2;
            //for (int i = 0; i < A.Length; i++)
            //    A[i] = 0;
            //for (int i = 0; i < B.Length; i++)
            //    B[i] = 0;
            //int Ai = 0;
            //int Bi = 0;
            //int Arrayi = 0;
            //for (int j1 = 0; j1 < SerLen; j1++)
            //{
            //    Rezalt.reinstallation++;
            //    A[Ai] = array[j1];
            //    Ai++;
            //}

            //for (int j1 = SerLen; j1 < n; j1++)
            //{
            //    Rezalt.reinstallation++;
            //    B[Bi] = array[j1];
            //    Bi++;
            //}
            //Ai = 0;
            //Bi = 0;
            //while ((Ai < SerLen) && (Bi < n - SerLen))
            //{
            //    Rezalt.comparisons++;
            //    if (A[Ai] < B[Bi])
            //    {
            //        Rezalt.reinstallation++;
            //        array[Arrayi] = A[Ai];
            //        Ai++; Arrayi++;
            //    }
            //    else
            //    {
            //        Rezalt.reinstallation++;
            //        array[Arrayi] = B[Bi];
            //        Bi++; Arrayi++;
            //    }
            //}
            //while (Ai < SerLen)
            //{
            //    Rezalt.reinstallation++;
            //    array[Arrayi] = A[Ai];
            //    Ai++; Arrayi++;
            //}
            //while (Bi < n - SerLen)
            //{
            //    Rezalt.reinstallation++;
            //    array[Arrayi] = B[Bi];
            //    Bi++; Arrayi++;
            //}
            sw.Stop();
            Rezalt.time = (ulong)sw.ElapsedMilliseconds;
            return Rezalt;
        }
        static int[] Merge_Sort(int[] massive)
        {
            if (massive.Length == 1)
                return massive;
            int mid_point = massive.Length / 2;
            return Merge(Merge_Sort(massive.Take(mid_point).ToArray()), Merge_Sort(massive.Skip(mid_point).ToArray()));
        }

        static int[] Merge(int[] mass1, int[] mass2)
        {
            int a = 0, b = 0;
            int[] merged = new int[mass1.Length + mass2.Length];
            for (int i = 0; i < mass1.Length + mass2.Length; i++)
            {
                if (b < mass2.Length && a < mass1.Length)
                    if (mass1[a] > mass2[b])
                        merged[i] = mass2[b++];
                    else 
                        merged[i] = mass1[a++];
                else
                    if (b < mass2.Length)
                    merged[i] = mass2[b++];
                else
                    merged[i] = mass1[a++];
            }
            return merged;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label3.Visible = false;
            label3.Text = string.Empty;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 2; j < 6; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = "";
                }
            }
            Random rnd = new Random();
            int[] array = new int[Convert.ToInt32(numericUpDown1.Value)];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(0, array.Length);
            }
            int[] ar =Merge_Sort(array);
            rezult rez;
            if (dataGridView1.Rows[0].Cells[0].Value.Equals(true))
            {
                int[] array_tmp = (int[])array.Clone();
                rez = mergeSimple(array_tmp);
                dataGridView1.Rows[0].Cells[2].Value = Convert.ToString(rez.comparisons);
                dataGridView1.Rows[0].Cells[3].Value = Convert.ToString(rez.reinstallation);
                dataGridView1.Rows[0].Cells[4].Value = Convert.ToString(rez.time);
                if (Check(array_tmp))
                {
                    dataGridView1.Rows[0].Cells[5].Value = "да";
                }
                else
                {
                    dataGridView1.Rows[0].Cells[5].Value = "нет";
                }
            }
            if (dataGridView1.Rows[1].Cells[0].Value.Equals(true))
            {
                //int[] array_tmp = (int[])array.Clone();
                //rez = ViborSort(array_tmp);
                //dataGridView1.Rows[1].Cells[2].Value = Convert.ToString(rez.comparisons);
                //dataGridView1.Rows[1].Cells[3].Value = Convert.ToString(rez.reinstallation);
                //dataGridView1.Rows[1].Cells[4].Value = Convert.ToString(rez.time);
                //if (Check(rez.newArray))
                //{
                //    dataGridView1.Rows[1].Cells[5].Value = "да";
                //}
                //else
                //{
                //    dataGridView1.Rows[1].Cells[5].Value = "нет";
                //}
            }
            if (dataGridView1.Rows[2].Cells[0].Value.Equals(true))
            {
                //int[] array_tmp = (int[])array.Clone();
                //rez = SortingByDirectInclusions(array_tmp);
                //dataGridView1.Rows[2].Cells[2].Value = Convert.ToString(rez.comparisons);
                //dataGridView1.Rows[2].Cells[3].Value = Convert.ToString(rez.reinstallation);
                //dataGridView1.Rows[2].Cells[4].Value = Convert.ToString(rez.time);
                //if (Check(rez.newArray))
                //{
                //    dataGridView1.Rows[2].Cells[5].Value = "да";
                //}
                //else
                //{
                //    dataGridView1.Rows[2].Cells[5].Value = "нет";
                //}
            }
            if (dataGridView1.Rows[3].Cells[0].Value.Equals(true))
            {
                //int[] array_tmp = (int[])array.Clone();
                //rez = Quicksort(array_tmp, 0, array_tmp.Length);
                //dataGridView1.Rows[3].Cells[2].Value = Convert.ToString(rez.comparisons);
                //dataGridView1.Rows[3].Cells[3].Value = Convert.ToString(rez.reinstallation);
                //dataGridView1.Rows[3].Cells[4].Value = Convert.ToString(rez.time);
                //if (Check(rez.newArray))
                //{
                //    dataGridView1.Rows[3].Cells[5].Value = "да";
                //}
                //else
                //{
                //    dataGridView1.Rows[3].Cells[5].Value = "нет";
                //}
            }
            if (dataGridView1.Rows[4].Cells[0].Value.Equals(true))
            {
                //int[] array_tmp = (int[])array.Clone();
                //rez = ShellSort(array_tmp);
                //dataGridView1.Rows[4].Cells[2].Value = Convert.ToString(rez.comparisons);
                //dataGridView1.Rows[4].Cells[3].Value = Convert.ToString(rez.reinstallation);
                //dataGridView1.Rows[4].Cells[4].Value = Convert.ToString(rez.time);
                //if (Check(rez.newArray))
                //{
                //    dataGridView1.Rows[4].Cells[5].Value = "да";
                //}
                //else
                //{
                //    dataGridView1.Rows[4].Cells[5].Value = "нет";
                //}
            }

            bool cheked = false;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value.Equals(true))
                {
                    cheked = true;
                    break;
                }

            }
            if (!cheked)
            {
                label3.Visible = true;
                label3.Text = "Ничего не выбрано";
            }
        }

        public struct rezult
        {
            public ulong time;
            public ulong comparisons;
            public ulong reinstallation;

        }
    }

}
