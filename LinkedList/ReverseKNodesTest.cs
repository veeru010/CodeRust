using System;

namespace CodeRust.LinkedList
{
    public static class ReverseKNodesTest
    {
        public static void Run()
        {
            ListNode<int> head = new ListNode<int>(1);
            ListNode<int> node1 = new ListNode<int>(2);
            head.Next = node1;
            ListNode<int> node2 = new ListNode<int>(3);
            node1.Next = node2;
            ListNode<int> node3 = new ListNode<int>(4);
            node2.Next = node3;
            ListNode<int> node4 = new ListNode<int>(5);
            node3.Next = node4;
            ListNode<int> node5 = new ListNode<int>(6);
            node4.Next = node5;
            Console.WriteLine("Input :");
            head.Display();

            ReverseKNodes rk = new ReverseKNodes();
            var newHead = rk.Run<int>(head,8);
            Console.WriteLine("Reverse every 8 nodes");
            newHead.Display();
        }
    }

    public class ReverseKNodes
    {
        public ListNode<T> Run<T>(ListNode<T> head,int k)
        {
            if(head == null || head.Next == null || k <= 1) return head;

            int length = head.Length();

            if(k > length)
                k = length;

            int maxIterations = length/k;
            int iteration = 0;          
            var pointer = head;
            ListNode<T> newHead = null;
            ListNode<T> newTail = null;
            while(iteration < maxIterations)
            {
               var startPointer = pointer;
               var endPointer = pointer;
               int i = 0;
               pointer = pointer.Next;
               while(i < k - 1)
               {
                   var temp = pointer;
                   pointer = pointer.Next;
                   temp.Next = startPointer;
                   startPointer = temp;
                   i++;
               }

               if(newHead == null)
               {
                   newHead = startPointer;                   
               }               
               else
               {
                   newTail.Next = startPointer;
               }

               newTail = endPointer;
               iteration++;
            }

            newTail.Next = pointer;
            return newHead;
        }
    }
}