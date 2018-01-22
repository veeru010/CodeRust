using System;

namespace CodeRust.LinkedList
{
    public static class RotateLinkedListTest
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
            RotateLinkedList rl = new RotateLinkedList();
            var newHead = rl.Run<int>(head,8);
            Console.WriteLine("Rotate By 8");
            newHead.Display();
        }
    }

    public class RotateLinkedList
    {
        public ListNode<T> Run<T>(ListNode<T> head,int n)
        {
            if(head == null || head.Next == null) return head;
            int length = head.Length();
            n = n%length;
            if(n < 0)
                n = length+n;
                        
            var slowPointer = head;
            var fastPointer = head;
            int i = 0;
            while(i < n)
            {
                fastPointer = fastPointer.Next;
                i++;
            }

            while(fastPointer.Next != null)
            {
                slowPointer = slowPointer.Next;
                fastPointer = fastPointer.Next;
            }

            var newHead = slowPointer.Next;
            slowPointer.Next = null;
            fastPointer.Next = head;
            return newHead;
        }
    }
}