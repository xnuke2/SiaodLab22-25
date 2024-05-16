using System;
using System.Diagnostics;
using System.Reflection;
using System.Security.Cryptography;
using static SiaodLab22_25.Form1;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections;
using System.CodeDom;

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

        Rezult mergeSimple(int[] array)
        {
            Rezult Rezalt = new Rezult();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int n = array.Length;
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
                while ((Aindex < AInd) && (Bindex < BInd))
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
                while (Aindex < AInd)
                {
                    Rezalt.reinstallation++;
                    array[Arrayindex] = A[Aindex];
                    Aindex++; Arrayindex++;
                }
                while (Bindex < BInd)
                {
                    Rezalt.reinstallation++;
                    array[Arrayindex] = B[Bindex];
                    Bindex++; Arrayindex++;
                }
                step = step + SerLen;
                SerLen = SerLen * 2;
            }
            sw.Stop();
            Rezalt.time = (ulong)sw.ElapsedMilliseconds;
            return Rezalt;
        }
        Rezult mergeOnePhase(int[] array)
        {
            Rezult Rezalt = new Rezult();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int n = array.Length;
            int[] A = new int[n];
            int[] B = new int[n];
            int[] AM = new int[n];
            int[] BM = new int[n];
            bool AB = true;
            int AInd = 0; int BInd = 0;
            int st = 0;
            int SerLen = 1;

            while (st + SerLen < n)
            {
                if (AB)
                {
                    for (int j1 = st; j1 < st + SerLen; j1++)
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

            };
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
            int ALIndex = AInd; int BLIndex = BInd;
            while (SerLen < array.Length)
            {
                int step = SerLen;
                int Aindex = 0;
                int Bindex = 0;
                int AMindex = 0;
                int BMindex = 0;
                AB = true;
                while (step <= ALIndex && step <= BLIndex)
                {
                    if (AB)
                    {
                        while ((Aindex < step) && (Bindex < step))
                        {
                            Rezalt.comparisons++;
                            if (A[Aindex] < B[Bindex])
                            {
                                Rezalt.reinstallation++;
                                AM[AMindex] = A[Aindex];
                                Aindex++; AMindex++;
                            }
                            else
                            {
                                Rezalt.reinstallation++;
                                AM[AMindex] = B[Bindex];
                                Bindex++; AMindex++;
                            }
                        }
                        while (Aindex < step)
                        {
                            Rezalt.reinstallation++;
                            AM[AMindex] = A[Aindex];
                            Aindex++; AMindex++;
                        }
                        while (Bindex < step)
                        {
                            Rezalt.reinstallation++;
                            AM[AMindex] = B[Bindex];
                            Bindex++; AMindex++;
                        }
                        step = step + SerLen;

                        AB = false;
                    }
                    else
                    {
                        while ((Aindex < step) && (Bindex < step))
                        {
                            Rezalt.comparisons++;
                            if (A[Aindex] < B[Bindex])
                            {
                                Rezalt.reinstallation++;
                                BM[BMindex] = A[Aindex];
                                Aindex++; BMindex++;
                            }
                            else
                            {
                                Rezalt.reinstallation++;
                                BM[BMindex] = B[Bindex];
                                Bindex++; BMindex++;
                            }
                        }
                        while (Aindex < step)
                        {
                            Rezalt.reinstallation++;
                            BM[BMindex] = A[Aindex];
                            Aindex++; BMindex++;
                        }
                        while (Bindex < step)
                        {
                            Rezalt.reinstallation++;
                            BM[BMindex] = B[Bindex];
                            Bindex++; BMindex++;
                        }
                        step = step + SerLen;
                        AB = true;
                    }

                }
                if (AB)
                {
                    while ((Aindex < ALIndex) && (Bindex < BLIndex))
                    {
                        Rezalt.comparisons++;
                        if (A[Aindex] < B[Bindex])
                        {
                            Rezalt.reinstallation++;
                            AM[AMindex] = A[Aindex];
                            Aindex++; AMindex++;
                        }
                        else
                        {
                            Rezalt.reinstallation++;
                            AM[AMindex] = B[Bindex];
                            Bindex++; AMindex++;
                        }
                    }
                    while (Aindex < ALIndex)
                    {
                        Rezalt.reinstallation++;
                        AM[AMindex] = A[Aindex];
                        Aindex++; AMindex++;
                    }
                    while (Bindex < BLIndex)
                    {
                        Rezalt.reinstallation++;
                        AM[AMindex] = B[Bindex];
                        Bindex++; AMindex++;
                    }

                }
                else
                {
                    while ((Aindex < ALIndex) && (Bindex < BLIndex))
                    {
                        Rezalt.comparisons++;
                        if (A[Aindex] < B[Bindex])
                        {
                            Rezalt.reinstallation++;
                            BM[BMindex] = A[Aindex];
                            Aindex++; BMindex++;
                        }
                        else
                        {
                            Rezalt.reinstallation++;
                            BM[BMindex] = B[Bindex];
                            Bindex++; BMindex++;
                        }
                    }
                    while (Aindex < ALIndex)
                    {
                        Rezalt.reinstallation++;
                        BM[BMindex] = A[Aindex];
                        Aindex++; BMindex++;
                    }
                    while (Bindex < BLIndex)
                    {
                        Rezalt.reinstallation++;
                        BM[BMindex] = B[Bindex];
                        Bindex++; BMindex++;
                    }


                }
                ALIndex = AMindex;
                BLIndex = BMindex;
                SerLen = SerLen * 2;
                (A, AM) = (AM, A);
                (B, BM) = (BM, B);
            }
            for(int i =0 ; i < A.Length; i++)
            {
            array[i] = A[i];
            }
            sw.Stop();
            Rezalt.time = (ulong)sw.ElapsedMilliseconds;
            return Rezalt;
        }

        Rezult mergeNatural(int[] array)
        {
            Rezult Rezalt = new Rezult();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int n = array.Length;
            int AInd = 1; int BInd = 1; int SerInd;
            while (true)
            {
                int[] A = new int[n];
                int[] B = new int[n];
                bool AB = true;
                AInd = 0; BInd = 0; SerInd = 0;
                while (SerInd < n)
                {
                   if (AB)
                    {
                        A[AInd++] = array[SerInd++];
                        while(SerInd < n && array[SerInd - 1] <= array[SerInd])
                        {
                            Rezalt.comparisons++;
                            Rezalt.reinstallation++;
                            A[AInd++] = array[SerInd++];                            
                        }
                        Rezalt.comparisons++;
                        AB = false;
                    }
                    else
                    {
                        B[BInd++] = array[SerInd++];
                        while (SerInd < n && array[SerInd - 1] <= array[SerInd])
                        {
                            Rezalt.comparisons++;
                            Rezalt.reinstallation++;
                            B[BInd++] = array[SerInd++];
                        }
                        Rezalt.comparisons++;
                        AB = true;
                    }

                };
                if (BInd == 0) break;
                int Aindex = 0;
                int Bindex = 0;
                int Arrayindex = 0;
                int AendSer;
                int BendSer;
                while (Aindex < AInd && Bindex < BInd)
                {
                    int Btmp = Bindex;
                    while (Btmp < BInd && B[Btmp] <= B[Btmp + 1])
                    {
                        Rezalt.comparisons++;
                        Btmp++;
                    }
                    Rezalt.comparisons++;
                    BendSer = Btmp;
                    if (BendSer == BInd) BendSer--;
                    int Atmp = Aindex;
                    while (Atmp < AInd && (A[Atmp] <= A[Atmp + 1]))
                    {
                        Rezalt.comparisons++;
                        Atmp++;
                    }
                    Rezalt.comparisons++;
                    AendSer = Atmp;
                    if (AendSer == AInd) AendSer--;
                    while (Aindex <= AendSer && Bindex <= BendSer)
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
                    while (Bindex <= BendSer)
                    {
                        Rezalt.reinstallation++;
                        array[Arrayindex] = B[Bindex];
                        Bindex++; Arrayindex++;
                    }
                    while (Aindex <= AendSer)
                    {
                        Rezalt.reinstallation++;
                        array[Arrayindex++] = A[Aindex++];
                    }

                }



                while (Bindex < BInd)
                {
                    Rezalt.reinstallation++;
                    array[Arrayindex++] = B[Bindex++];

                }
                while (Aindex < AInd)
                {
                    Rezalt.reinstallation++;
                    array[Arrayindex++] = A[Aindex++];
                }
            }
            sw.Stop();
            Rezalt.time = (ulong)sw.ElapsedMilliseconds;
            return Rezalt;
        }

        Rezult mergeNaturalOnePhase(int[] array)
        {
            Rezult Rezalt = new Rezult();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int n = array.Length;
            int[] A = new int[n];
            int[] B = new int[n];
            int[] AM = new int[n];
            int[] BM = new int[n];
            bool AB = true;
            int AInd = 0; int BInd = 0;int SerInd = 0;


            while (SerInd < n)
            {
                if (AB)
                {
                    A[AInd++] = array[SerInd++];
                    while (SerInd < n && array[SerInd - 1] <= array[SerInd])
                    {
                        Rezalt.comparisons++;
                        Rezalt.reinstallation++;
                        A[AInd++] = array[SerInd++];
                    }
                    Rezalt.comparisons++;
                    AB = false;
                }
                else
                {
                    B[BInd++] = array[SerInd++];
                    while (SerInd < n && array[SerInd - 1] <= array[SerInd])
                    {
                        Rezalt.comparisons++;
                        Rezalt.reinstallation++;
                        B[BInd++] = array[SerInd++];
                    }
                    Rezalt.comparisons++;
                    AB = true;
                }

            };

            while (true)
            {
                
                int Aindex = 0;
                int Bindex = 0;
                int AArrayindex = 0;
                int BArrayindex = 0;
                int AendSer;
                int BendSer;
                AB = true;
                while (Aindex < AInd || Bindex < BInd)
                {
                    if (AB)
                    {
                        int Btmp = Bindex;
                        while (Btmp < BInd - 1 && B[Btmp] <= B[Btmp + 1])
                        {
                            Rezalt.comparisons++;
                            Btmp++;
                        }
                        Rezalt.comparisons++;
                        BendSer = Btmp;
                        if (BendSer == BInd) BendSer--;
                        
                        int Atmp = Aindex;
                        while (Atmp < AInd-1 && (A[Atmp] <= A[Atmp + 1]))
                        {
                            Rezalt.comparisons++;
                            Atmp++;
                        }
                        Rezalt.comparisons++;
                        AendSer = Atmp;
                        if(AendSer == AInd) AendSer--;
                        while (Aindex <= AendSer && Bindex <= BendSer)
                        {
                            Rezalt.comparisons++;
                            if (A[Aindex] < B[Bindex])
                            {
                                Rezalt.reinstallation++;
                                AM[AArrayindex++] = A[Aindex++];
                            }
                            else
                            {
                                Rezalt.reinstallation++;
                                AM[AArrayindex++] = B[Bindex++];
                            }
                        }
                        while (Bindex <= BendSer)
                        {
                            Rezalt.reinstallation++;
                            AM[AArrayindex++] = B[Bindex++];
                        }
                        while (Aindex <= AendSer)
                        {
                            Rezalt.reinstallation++;
                            AM[AArrayindex++] = A[Aindex++];
                        }
                        AB = false;
                    }
                    else
                    {
                        int Btmp = Bindex;
                        while (Btmp < BInd - 1 && B[Btmp] <= B[Btmp + 1])
                        {
                            Rezalt.comparisons++;
                            Btmp++;
                        }
                        Rezalt.comparisons++;
                        BendSer = Btmp;
                        if (BendSer == BInd) BendSer--;
                        int Atmp = Aindex;
                        while (Atmp < AInd - 1 && (A[Atmp] <= A[Atmp + 1]))
                        {
                            Rezalt.comparisons++;
                            Atmp++;
                        }
                        Rezalt.comparisons++;
                        AendSer = Atmp;
                        if (AendSer == AInd) AendSer--;
                        while (Aindex <= AendSer && Bindex <= BendSer)
                        {
                            Rezalt.comparisons++;
                            if (A[Aindex] < B[Bindex])
                            {
                                Rezalt.reinstallation++;
                                BM[BArrayindex++] = A[Aindex++];
                            }
                            else
                            {
                                Rezalt.reinstallation++;
                                BM[BArrayindex++] = B[Bindex++];
                            }
                        }
                        while (Bindex <= BendSer)
                        {
                            Rezalt.reinstallation++;
                            BM[BArrayindex++] = B[Bindex++];
                        }
                        while (Aindex <= AendSer)
                        {
                            Rezalt.reinstallation++;
                            BM[BArrayindex++] = A[Aindex++];
                        }
                        AB = true;
                    }

                }
                for (int i = 0; i < AM.Length; i++) 
                {
                    A[i] = AM[i];
                    B[i] = BM[i];
                    AM[i] = 0;
                    BM[i] = 0;
                }
                AInd = AArrayindex; BInd = BArrayindex;
                if (BInd == 0) break;
            }

            for (int i = 0; i < A.Length; i++)
            {
                array[i] = A[i];
            }
            sw.Stop();
            Rezalt.time = (ulong)sw.ElapsedMilliseconds;
            return Rezalt;
        }

        Rezult absorbtionSort(int[] array)
        {
            Rezult rezult = new Rezult();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int lengthArray = array.Length;
            int len = lengthArray * Convert.ToInt32(numericUpDown2.Value) / 100;
            int[] tmpArray =new int[len];
            int curInd = lengthArray -len- 1;
            int indTmpArray, indSort, Ind, sInd;
            Array.Sort(array, lengthArray - len, len);
            for(int i = 1; i < lengthArray / len; i++)
            {
                indTmpArray = 0;
                while (curInd > lengthArray - (i+1)*len - 1)
                {
                    rezult.reinstallation++;
                    tmpArray[indTmpArray++] = array[curInd--];
                }
                Array.Sort(tmpArray);
                indSort = 0;
                Ind = curInd+1;
                sInd = curInd + len+1;

                while(indSort< indTmpArray&&sInd< lengthArray)
                {
                    rezult.comparisons++;
                    array[Ind++] = tmpArray[indSort] < array[sInd] ? tmpArray[indSort++] : array[sInd++];
                    rezult.reinstallation++;
                }
                while(indSort< indTmpArray)
                {
                    rezult.reinstallation++;
                    array[Ind++] = tmpArray[indSort++];
                }
                while (sInd < lengthArray)
                {
                    rezult.reinstallation++;
                    array[Ind++] = array[sInd++];
                }
            }
            indTmpArray = 0;
            while (curInd >= 0)
            {
                rezult.reinstallation++;
                tmpArray[indTmpArray++] = array[curInd--];
            }
            Array.Sort(tmpArray,0,indTmpArray+1);
            indSort = 0;
            Ind = curInd + 1;
            sInd =indTmpArray;
            while (indSort < indTmpArray && sInd < lengthArray)
            {
                rezult.comparisons++;
                array[Ind++] = tmpArray[indSort] < array[sInd] ? tmpArray[indSort++] : array[sInd++];
                rezult.reinstallation++;
            }
            while (indSort < indTmpArray)
            {
                rezult.reinstallation++;
                array[Ind++] = tmpArray[indSort++];
            }
            while (sInd < lengthArray)
            {
                rezult.reinstallation++;
                array[Ind++] = array[sInd++];
            }
            sw.Stop();
            rezult.time =(ulong)sw.ElapsedMilliseconds;
            return rezult;
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
            Rezult rez;
            if (dataGridView1.Rows[0].Cells[0].Value.Equals(true))
            {
                int[] array_tmp = (int[])array.Clone();
                rez = mergeSimple(array_tmp);
                dataGridView1.Rows[0].Cells[2].Value = Convert.ToString(rez.comparisons);
                dataGridView1.Rows[0].Cells[3].Value = Convert.ToString(rez.reinstallation);
                dataGridView1.Rows[0].Cells[4].Value = Convert.ToString(rez.time);
                dataGridView1.Rows[0].Cells[5].Value = Check(array_tmp) ? "Да" : "Нет";
            }
            if (dataGridView1.Rows[1].Cells[0].Value.Equals(true))
            {
                int[] array_tmp = (int[])array.Clone();
                rez = mergeOnePhase(array_tmp);
                dataGridView1.Rows[1].Cells[2].Value = Convert.ToString(rez.comparisons);
                dataGridView1.Rows[1].Cells[3].Value = Convert.ToString(rez.reinstallation);
                dataGridView1.Rows[1].Cells[4].Value = Convert.ToString(rez.time);
                dataGridView1.Rows[1].Cells[5].Value = Check(array_tmp) ? "Да" : "Нет";
            }
            if (dataGridView1.Rows[2].Cells[0].Value.Equals(true))
            {
                int[] array_tmp = (int[])array.Clone();
                rez = mergeNatural(array_tmp);
                dataGridView1.Rows[2].Cells[2].Value = Convert.ToString(rez.comparisons);
                dataGridView1.Rows[2].Cells[3].Value = Convert.ToString(rez.reinstallation);
                dataGridView1.Rows[2].Cells[4].Value = Convert.ToString(rez.time);
                dataGridView1.Rows[2].Cells[5].Value= Check(array_tmp)?"Да":"Нет";
            }
            if (dataGridView1.Rows[3].Cells[0].Value.Equals(true))
            {
                int[] array_tmp = (int[])array.Clone();
                rez = mergeNaturalOnePhase(array_tmp);
                dataGridView1.Rows[3].Cells[2].Value = Convert.ToString(rez.comparisons);
                dataGridView1.Rows[3].Cells[3].Value = Convert.ToString(rez.reinstallation);
                dataGridView1.Rows[3].Cells[4].Value = Convert.ToString(rez.time);
                dataGridView1.Rows[3].Cells[5].Value = Check(array_tmp) ? "Да" : "Нет";
            }
            if (dataGridView1.Rows[4].Cells[0].Value.Equals(true))
            {
                int[] array_tmp = (int[])array.Clone();
                rez = absorbtionSort(array_tmp);
                dataGridView1.Rows[4].Cells[2].Value = Convert.ToString(rez.comparisons);
                dataGridView1.Rows[4].Cells[3].Value = Convert.ToString(rez.reinstallation);
                dataGridView1.Rows[4].Cells[4].Value = Convert.ToString(rez.time);
                dataGridView1.Rows[4].Cells[5].Value = Check(array_tmp) ? "Да" : "Нет";
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

        public struct Rezult
        {
            public ulong time;
            public ulong comparisons;
            public ulong reinstallation;

        }
    }

}
//while (Aindex < AInd && Bindex < BInd)
//{
//    while (B[Bindex] <= B[Bindex + 1] && A[Aindex] <= A[Aindex + 1])
//    {
//        Rezalt.comparisons++;
//        if (A[Aindex] < B[Bindex])
//        {
//            Rezalt.reinstallation++;
//            array[Arrayindex] = A[Aindex];
//            Aindex++; Arrayindex++;
//        }
//        else
//        {
//            Rezalt.reinstallation++;
//            array[Arrayindex] = B[Bindex];
//            Bindex++; Arrayindex++;
//        }
//    }
//    if (!(B[Bindex] <= B[Bindex + 1]))
//    {
//        BendSer = Bindex;
//        int Atmp = Aindex;
//        while (Atmp < AInd && (A[Atmp] <= A[Atmp + 1]))
//        {
//            Atmp++;
//        }
//        AendSer = Atmp;
//        Rezalt.comparisons++;
//        while (Bindex <= BendSer && Aindex <= AendSer)
//            if (A[Aindex] < B[Bindex])
//            {
//                Rezalt.reinstallation++;
//                array[Arrayindex] = A[Aindex];
//                Aindex++; Arrayindex++;
//            }
//            else
//            {
//                Rezalt.reinstallation++;
//                array[Arrayindex] = B[Bindex];
//                Bindex++; Arrayindex++;
//            }

//        while (Bindex <= BendSer)
//        {
//            Rezalt.reinstallation++;
//            array[Arrayindex] = B[Bindex];
//            Bindex++; Arrayindex++;
//        }

//        while (Aindex <= AendSer)
//        {
//            Rezalt.reinstallation++;
//            array[Arrayindex++] = A[Aindex++];
//        }
//    }
//    else
//    {
//        AendSer = Aindex;
//        int Btmp = Bindex;
//        while (Btmp < BInd && B[Btmp] <= B[Btmp + 1])
//        {
//            Btmp++;
//        }
//        BendSer = Btmp;
//        while (Bindex <= BendSer && Aindex <= AendSer)
//            if (A[Aindex] < B[Bindex])
//            {
//                Rezalt.reinstallation++;
//                array[Arrayindex] = A[Aindex];
//                Aindex++; Arrayindex++;
//            }
//            else
//            {
//                Rezalt.reinstallation++;
//                array[Arrayindex] = B[Bindex];
//                Bindex++; Arrayindex++;
//            }

//        while (Bindex <= BendSer)
//        {
//            Rezalt.reinstallation++;
//            array[Arrayindex] = B[Bindex];
//            Bindex++; Arrayindex++;
//        }

//        while (Aindex <= AendSer)
//        {
//            Rezalt.reinstallation++;
//            array[Arrayindex++] = A[Aindex++];
//        }

//    }

//}
//while (Aindex < AInd && Bindex < BInd)
//{
//    Rezalt.comparisons++;
//    if (A[Aindex] < B[Bindex])
//    {
//        Rezalt.reinstallation++;
//        array[Arrayindex] = A[Aindex];
//        Aindex++; Arrayindex++;
//    }
//    else
//    {
//        Rezalt.reinstallation++;
//        array[Arrayindex] = B[Bindex];
//        Bindex++; Arrayindex++;
//    }
//}