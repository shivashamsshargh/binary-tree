//shiva shams

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace project_3
{
    public class node
    {
        public node right;
        public node left;
        public node parent;
        public int Data;
        public node()
        {
            right = null;
            left = null;
            parent = null;
            Data = 0;
        }
    }
    public class Tree
    {
        public node root;
        public int treeSize;//Size Of TREE
        public int sum;
        public Tree() //Constructor function
        {
            treeSize = 0;
            sum = 0;
            root = null;
        }
        public void Insert_node(int data)//Add node to TREE
        {
            node z = new node();
            z.Data = data;
            node x = root;
            node y = x;
            if (root == null)//derakht khalie
            {
                root = z;
            }
            else
            {
                if (data <= root.Data)
                {
                    if (x.left == null)
                    {
                        z.parent = x;
                        x.left = z;
                    }
                    else
                    {
                        x = x.left;
                        while (x != null)//Find node location to add
                        {
                            y = x;
                            if (data % 2 == 0) //age zoj bod farzand haye rast ro check kone
                            {
                                x = x.right;
                            }
                            else
                                x = x.left;
                        }
                        z.parent = y;
                        if (z.Data % 2 != 0) //age fard bod mishe farzand chap
                            y.left = z;
                        else
                            y.right = z;// age zoj bood mishe farzand rast
                    }

                }
                if (data > root.Data)
                {
                    if (x.right == null)
                    {
                        z.parent = x;
                        x.right = z;
                    }
                    else
                    {
                        x = x.right;
                        while (x != null)//Find node location to add
                        {
                            y = x;
                            if (data % 2 == 0)
                            {
                                x = x.right;
                            }
                            else
                                x = x.left;
                        }
                        z.parent = y;
                        if (z.Data % 2 != 0)
                            y.left = z;
                        else
                            y.right = z;
                    }

                }
            }
            sum = sum + data;
            treeSize++;
        }
        /// <summary>
        /// ////////////////////////////////////
        public void transplant(node u, node v)//Moving two subtrees for the delete function
        {
            if (u.parent == null)
                root = v;
            else if (u == u.parent.left)
                u.parent.left = v;
            else
                u.parent.right = v;
            if (v != null)
                v.parent = u.parent;
        }
        public void Delete(int data)//Delete a node with specific data
        {
            int q = 0;
            node x = root;
            node y = x;
            if (data == root.Data)
            {
                q = 1;
            }
            else if (data < root.Data)
            {
                x = x.left;
                if (data % 2 == 0)
                {
                    while (x != null)
                    {
                        if (x.Data == data)
                        {
                            q = 1;
                            break;
                        }
                        else
                        {
                            y = x;
                            x = x.right;
                        }
                    }
                }
                else
                {
                    while (x != null)
                    {
                        if (x.Data == data)
                        {
                            q = 1;
                            break;
                        }
                        else
                        {
                            y = x;
                            x = x.left;
                        }
                    }
                }
            }
            else if (data > root.Data)
            {
                x = x.right;
                if (data % 2 == 0)
                {
                    while (x != null)
                    {
                        if (x.Data == data)
                        {
                            q = 1;
                            break;
                        }
                        else
                        {
                            y = x;
                            x = x.right;
                        }
                    }
                }
                else
                {
                    while (x != null)
                    {
                        if (x.Data == data)
                        {
                            q = 1;
                            break;
                        }
                        else
                        {
                            y = x;
                            x = x.left;
                        }
                    }
                }
            }
            if (q == 0)
            {
                Console.WriteLine("!!!!!!!!!ERROR!!!!!!!!!");
            }
            else
            {
                //age x khode rishe bashe
                if (x == root)
                {
                    //bozorgtrin node samte rast rishe ast
                    node s;
                    node w;
                    s = x.right;
                    //age samt rast zir derakht nadsht
                    if (s.left == null && s.right == null)
                    {
                        if (s == x.right)
                        {
                            transplant(x, s);
                            s.left = x.left;
                        }
                    }
                    else if (s.right != null && s.left != null)
                    {
                        if (s.left.Data > s.right.Data)
                            w = s.left;
                        else
                            w = s.right;
                        node t = s.left;
                        node d = x.left;
                        s.left = null;
                        x.left = null;
                        transplant(x, s);
                        w.left = t;
                        s.left = d;
                    }
                    //age samt rast zir derakht rast dashte bashe
                    else if (s.right != null)
                    {
                        transplant(x, s);
                        s.left = x.left;
                    }
                    //age samt rast zir derakht chap dashte bashe
                    else if (s.left != null)
                    {
                        node e = s.left;
                        transplant(x, s);
                        s.left = x.left;
                        s.right = e;
                    }
                }
                //age farzandi ndashte bashe
                else if (x.left == null && x.right == null)
                {
                    //age x farzand rast bashe
                    if (y.right == x)
                    {
                        y.right = null;
                        x.parent = null;
                    }
                    //age x farzand chap bashe
                    else
                    {
                        y.left = null;
                        x.parent = null;
                    }
                }
                //age 2 ta frazand dashte bashe
                else if (x.right != null && x.left != null)
                {
                    // bozorg tarin farzand jaygozin mishe
                    node z;
                    if (x.left.Data > x.right.Data)
                        z = x.left;
                    else
                        z = x.right;
                    //age node morede nazar samt rast rishe bashe
                    if (x == root.right)
                    {
                        //age z samte rase x 
                        if (z == x.right)
                        {
                            z.left = x.left;
                            transplant(x, z);
                        }
                        //age z samte chape x
                        else
                        {
                            z.right = x.right;
                            transplant(x, z);
                        }
                    }
                    else if (x == root.left)
                    {
                        //age z samte rase x 
                        if (z == x.right)
                        {
                            z.left = x.left;
                            transplant(x, z);
                        }
                        //age z samte chape x
                        else
                        {
                            z.right = x.right;
                            transplant(x, z);
                        }
                    }
                }
                //age 1 farzand dashte bashe
                else if (x.right != null)
                {
                    transplant(x, x.right);
                }
                else if (x.left != null)
                {
                    transplant(x, x.left);
                }
                sum = sum - data;
                treeSize--;
                Console.WriteLine("-----DONE-----");
            }
        }
        ////////////////////////////////////////////
        public void PreOrder(node parent)
        {
            if (parent != null)
            {
                Console.Write(parent.Data + " ");
                PreOrder(parent.left);
                PreOrder(parent.right);
            }
        }
        public void InOrder(node parent)
        {
            if (parent != null)
            {
                InOrder(parent.left);
                Console.Write(parent.Data + " ");
                InOrder(parent.right);
            }
        }
        public void PostOrder(node parent)
        {
            if (parent != null)
            {
                PostOrder(parent.left);
                PostOrder(parent.right);
                Console.Write(parent.Data + " ");
            }
        }
        ///////////////////////
        public int Depth(node node)
        {
            if (node == null)
                return 0;
            else
            {
                //omq har zir derakht ro hesab mikone
                int lDepth = Depth(node.left);
                int rDepth = Depth(node.right);
                // bozorgtrin ro entekhab mikone
                if (lDepth > rDepth)
                    return (lDepth + 1);
                else
                    return (rDepth + 1);
            }
        }
        public int Leaf(node node)
        {
            if (node == null)
            {
                return 0;
            }
            if (node.left == null && node.right == null)
            {
                return 1;
            }
            else
            {
                return Leaf(node.left) + Leaf(node.right);
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Tree tree = new Tree();//sakht derakht
            int k = 1;
            while (k != 0)
            {
                Console.WriteLine("\n" +
                    "\n1- Insert To Tree " +
                    "\n2- Find & Delete from TREE" +
                    "\n3- Print SUM of Nodes" +
                    "\n4- Depth of TREE" +
                    "\n5- Count of Nodes" +
                    "\n6- Leaf of TREE" +
                    "\n7- Print Preorder" +
                    "\n8- Print Postorder" +
                    "\n9- Print Inorder ");
                Console.Write("\nPlease enter number to do function or enter '0' to exit:  ");
                k = Convert.ToInt32(Console.ReadLine());
                switch (k)
                {
                    case 0:
                        break;
                    case 1:
                        while (true)
                        {
                            Console.Write("\nplease enter the number. for exit enter !!e!!:  ");
                            string q = Console.ReadLine();
                            if (q == "e")
                                break;
                            else
                            {
                                tree.Insert_node(Convert.ToInt32(q));
                            }
                        }
                        Console.WriteLine("-**--DONE--**-");
                        break;
                    case 2:
                        Console.Write("\nplease enter the number to Delete: ");
                        int w = Convert.ToInt32(Console.ReadLine());
                        tree.Delete(w);
                        break;
                    case 3:
                        Console.Write("\nSum of nodes = {0} ", tree.sum);
                        break;
                    case 4:
                        Console.Write("\nDepth of nodes = {0} ", tree.Depth(tree.root));
                        Console.WriteLine();
                        break;
                    case 5:
                        Console.Write("\nCount of nodes = {0} ", tree.treeSize);
                        Console.WriteLine();
                        break;
                    case 6:
                        Console.Write("\nCount of Leaf = {0} ", tree.Leaf(tree.root));
                        Console.WriteLine();
                        break;
                    case 7:
                        Console.WriteLine();
                        tree.PreOrder(tree.root);
                        break;
                    case 8:
                        Console.WriteLine();
                        tree.PostOrder(tree.root);
                        break;
                    case 9:
                        Console.WriteLine();
                        tree.InOrder(tree.root);
                        break;
                }
            }
            Console.ReadKey();
        }
    }
}
