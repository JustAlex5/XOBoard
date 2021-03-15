using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOBoard
{
    class XOBoard
    {
        private int p1_score;
        private int p2_score;
        private String[,] matrix; 
        private int row;
        private int col;
        private int size;
        

        public XOBoard(int size=3)
        {
            this.size = size;
            if (size == 3)
            {
                matrix = new string[,] {
                                     {"1","2","3"},
                                     {"4","5","6"},
                                     {"7","8","9"}};
            }
            else matrix = createMatrix();
            p1_score = 0;
            p2_score = 0;
        }
        //public XOBoard(int size=3)
        //{
        //    this.size = size;
        //    matrix = new string[size, size];
        //}
        public void put()
        {
            Boolean status;
            int x;
            Random rnd = new Random();
            if (rnd.Next() % 2 == 0) System.Console.WriteLine("Player 1 play first");
            else System.Console.WriteLine("Player 2 play fisrt");
            System.Console.WriteLine("\n");
            Display();
            for (int i = 0; i < size*size; i++)
            {
                
                do
                {
                    x = Convert.ToInt32(Console.ReadLine());
                    
                    row = --x / size;
                    col =  (x % size);
                    
                    if(matrix[row,col]=="X"|| matrix[row, col] == "O")
                    {
                        System.Console.WriteLine("This place {0},{1} isnt avalid",row,col);
                    }


                } while (matrix[row, col] == "X" || matrix[row, col] == "O");
                if (i % 2 == 0) matrix[row, col] = "X".ToString();
                else matrix[row, col] = "O".ToString();
                Display();

                if (Status())
                {
                    System.Console.WriteLine("press any key ");
                    System.Console.ReadKey();
                    break;
                }
                

            }
            System.Console.WriteLine("Tie");

            System.Console.WriteLine("press any key ");
            System.Console.ReadKey();

        }

        public Boolean Status()
        {
            int count_row=1;
            int count_col = 1;
            int count_maindiag = 1;
            int count_antidiag = 1;
            for (int i = 0; i < size-1; i++){
                for (int j = 0; j < size-1; j++)
                {
                    if (matrix[i, j] == matrix[i, j + 1]) count_row++;
                }
                if (count_row == size)
                {
                    System.Console.WriteLine("Player {0} win", matrix[i, 0]);
                    return true;
                }
                else count_row = 1;
            }

            for (int j = 0; j < size - 1; j++)
            {
                for (int i = 0; i < size - 1; i++)
                {
                    if (matrix[i, j] == matrix[i+1, j]) count_col++;
                }
                if (count_col == size)
                {
                    System.Console.WriteLine("Player {0} win", matrix[0, j]);
                    return true;
                }
                else count_col = 1;
            }

            for (int i = 0; i < size - 1; i++)
            {
                if (matrix[i, i] == matrix[i + 1, i + 1]) count_maindiag++;
                if (matrix[size-i-1, i] == matrix[size-1-i-1  , i + 1]) count_antidiag++;
            }
            if (count_maindiag == size)
            {
                System.Console.WriteLine("Player {0} win", matrix[0, 0]);
                return true;
            }
            if (count_antidiag == size)
            {
                System.Console.WriteLine("Player {0} win", matrix[size - 1, 0]);
                return true;
            }
            return false;
        }

        public void Display()
        {
            for(int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if ((i * size + j % size + 1 < 10) && matrix[i, j] != "X" && matrix[i, j]!= "O") System.Console.Write("| " +"0"+ matrix[i, j] + "  ");
                   else System.Console.Write("| "+matrix[i, j]+"  ");
                }
                System.Console.Write("|\n");
                System.Console.Write("\n");
                
            }
           

        }

        private String[,] createMatrix()
        {
            matrix = new string[size,size];
            int temp;
            for(int i = 0; i < size;i++)
            {
                for (int j = 0; j < size; j++)
                {
                    temp = i * size + j % size+1;
                    matrix[i, j] = temp.ToString();
                }
            }
            return matrix;
        }
            
        

    }
   

}
