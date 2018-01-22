using System;

namespace CodeRust.LinkedList
{
    public static class ReverseEvenNodesTest
    {
        public static void Run()
        {
            ListNode<int> head = new ListNode<int>(7);
            ListNode<int> node1 = new ListNode<int>(14);
            head.Next = node1;
            ListNode<int> node2 = new ListNode<int>(21);
            node1.Next = node2;
            ListNode<int> node3 = new ListNode<int>(28);
            node2.Next = node3;
            ListNode<int> node4 = new ListNode<int>(9);
            node3.Next = node4;
            ListNode<int> node5 = new ListNode<int>(16);
            node4.Next = node5;           
            Console.WriteLine("Input :");
            head.Display();

            ReverseEvenNodes re = new ReverseEvenNodes();
            re.Run<int>(head);
            Console.WriteLine("After Reversing Even nodes");
            head.Display();
        }
    }

    public class ReverseEvenNodes
    {
        public void Run<T>(ListNode<T> head)
        {
            if(head == null || head.Next == null || head.Next.Next == null) return;

            var oddPointer = head;
            var evenPointer = head.Next;            
            oddPointer.Next = evenPointer.Next;
            evenPointer.Next = null;
            oddPointer = oddPointer.Next;

            while(oddPointer != null && oddPointer.Next != null)
            {
                var temp = oddPointer.Next;
                oddPointer.Next = temp.Next;
                temp.Next = evenPointer;
                evenPointer = temp;
                oddPointer = oddPointer.Next;
            }

            oddPointer = head;
            
            while(evenPointer != null)
            {
                var temp = oddPointer.Next;
                oddPointer.Next = evenPointer;
                evenPointer = evenPointer.Next;
                oddPointer.Next.Next = temp;
                oddPointer = temp;              
            }            
        }
    }
}