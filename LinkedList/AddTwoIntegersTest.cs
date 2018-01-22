using System;

namespace CodeRust.LinkedList
{
    public static class AddTwoIntegersTest
    {
        public static void Run()
        {
            ListNode<int> integer1 = new ListNode<int>(1);
            ListNode<int> node11 = new ListNode<int>(0);
            integer1.Next = node11;
            ListNode<int> node12 = new ListNode<int>(9);
            node11.Next = node12;
            ListNode<int> node13 = new ListNode<int>(9);
            node12.Next = node13;

            Console.WriteLine("First Integer :");
            integer1.Display();

            ListNode<int> integer2 = new ListNode<int>(7);
            ListNode<int> node21 = new ListNode<int>(3);
            integer2.Next = node21;
            ListNode<int> node22 = new ListNode<int>(2);
            node21.Next = node22;

            Console.WriteLine("Second Integer :");
            integer2.Display();

            AddTwoIntegers at = new AddTwoIntegers();
            var result = at.Run(integer1,integer2);
            Console.WriteLine("Sum of two integers");
            result.Display();
        }
    }

    public class AddTwoIntegers
    {
        public ListNode<int> Run(ListNode<int> head1,ListNode<int> head2)
        {
            if(head1 == null) return head2;
            if(head2 == null) return head1;
            
            var pointer1 = head1;
            var pointer2 = head2;

            int sum = pointer1.NodeValue + pointer2.NodeValue;
            int carry = sum/10;

            ListNode<int> result = new ListNode<int>(sum%10);
            pointer1 = pointer1.Next;
            pointer2 = pointer2.Next;
            var pointer3 = result;

            while(pointer1 != null || pointer2 != null)
            {
                int val1 = (pointer1 == null) ? 0 : pointer1.NodeValue;
                int val2 = (pointer2 == null) ? 0 : pointer2.NodeValue;
                sum = val1+val2 + carry;
                carry = sum/10;
                pointer3.Next = new ListNode<int>(sum%10);
                pointer3 = pointer3.Next;
                pointer1 = pointer1?.Next;
                pointer2 = pointer2?.Next;
            }

            if(carry > 0)
                pointer3.Next = new ListNode<int>(carry);
            
            return result;
        }
    }
}