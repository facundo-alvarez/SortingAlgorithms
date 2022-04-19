using System.Diagnostics;

namespace SortingAlgorithms
{
    public partial class Form1 : Form
    {
        int[] numbers = new int[256];
        int start = 0;
        int end = 255;


        public Form1()
        {
            InitializeComponent();
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            numbers = Shuffle();
            viewPanel.Invalidate();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            ArrayGenerator();
            viewPanel.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ArrayGenerator();      
        }

        private void ArrayGenerator()
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = i;
            }
        }

        private Color RgbGenerator(int numb)
        {
            Color myRgbColor = new Color();
            myRgbColor = Color.FromArgb(0, numb, 0);
            return myRgbColor;
        }

        private int[] Shuffle()
        {
            Random r = new Random();
            return numbers.OrderBy(x => r.Next()).ToArray();
        }

        private void viewPanel_Paint(object sender, PaintEventArgs e)
        {
            int x = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                Pen pen = new Pen(RgbGenerator(numbers[i]));
                pen.Width = 4;
                e.Graphics.DrawLine(pen, x, 0, x, 461);
                x += 4;
                pen.Dispose();
            }
        }

        private void sortButton_Click(object sender, EventArgs e)
        {
            switch (algoBox.SelectedIndex)
            {
                case 0:
                    BubbleSort(numbers);
                    break;
                case 1:
                    QuickSort(numbers, start, end);
                    break;
                case 2:
                    InsertionSort(numbers);
                    break;
            }

        }

        private async void BubbleSort(int[] arr)
        {
            int temp;
            int length = arr.Length;
            for (int j = 0; j < length; j++)
            {
                for (int i = 0; i < length - 1; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        temp = arr[i + 1];
                        arr[i + 1] = arr[i];
                        arr[i] = temp;  
                        viewPanel.Refresh();
                    }
                }
            } 
        }

        private void QuickSort(int[] arr, int start, int end)
        {
            int i;
            if (start < end)
            {
                i = Partition(arr, start, end);

                QuickSort(arr, start, i - 1);
                QuickSort(arr, i + 1, end);
            }
        }

        private int Partition(int[] arr, int start, int end)
        {
            int temp;
            int p = arr[end];
            int i = start - 1;

            for (int j = start; j <= end - 1; j++)
            {
                if (arr[j] <= p)
                {
                    i++;
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    viewPanel.Refresh();
                }
            }
         
            temp = arr[i + 1];
            arr[i + 1] = arr[end];
            arr[end] = temp;
            return i + 1;
        }

        private void InsertionSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 1; i < n; ++i)
            {
                int key = arr[i];
                int j = i - 1;
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;

                    viewPanel.Refresh();
                }
                arr[j + 1] = key;
            }
        }
    }
}