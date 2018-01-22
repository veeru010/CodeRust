using System;

namespace CodeRust.LinkedList
{
    public static class MergeSortTest
    {
        public static void Run()
        {
            ListNode<int> head = new ListNode<int>(29);
            ListNode<int> node1 = new ListNode<int>(23);
            head.Next = node1;
            ListNode<int> node2 = new ListNode<int>(82);
            node1.Next = node2;
            ListNode<int> node3 = new ListNode<int>(11);
            node2.Next = node3;
            ListNode<int> node4 = new ListNode<int>(4);
            node3.Next = node4;
            ListNode<int> node5 = new ListNode<int>(3);
            node4.Next = node5;
            ListNode<int> node6 = new ListNode<int>(21);
            node5.Next = node6;
            Console.WriteLine("Input :");
            head.Display();

            MergeSort ms = new MergeSort();
            var sortedNode = ms.RunSort<int>(head);
            Console.WriteLine("After Sort :");
            sortedNode.Display();
        }
    }

    public class MergeSort
    {
        public ListNode<T> RunSort<T>(ListNode<T> head) where T : IComparable<T>
        {
            if(head == null || head.Next == null) return head;
            ListNode<T> secondHalf = SplitHalf<T>(head);
            var sortedFirstHalf = RunSort<T>(head);
            var sortedSecondHalf = RunSort<T>(secondHalf);
            return MergeSortedHalves<T>(sortedFirstHalf,sortedSecondHalf);
        }

        private ListNode<T> SplitHalf<T>(ListNode<T> head)
        {
            var slowPointer = head;
            var fastPointer = head.Next;

            while(fastPointer != null && fastPointer.Next != null)
            {
                slowPointer = slowPointer.Next;
                fastPointer = fastPointer.Next.Next;
            }

            var secondHalf = slowPointer.Next;
            slowPointer.Next = null;
            return secondHalf;
        }

        private ListNode<T> MergeSortedHalves<T>(ListNode<T> firstHalf,ListNode<T> secondHalf) where T : IComparable<T>
        {
            if(firstHalf == null) return secondHalf;
            if(secondHalf == null) return firstHalf;

            var pointer1 = firstHalf;
            var pointer2 = secondHalf;
            ListNode<T> mergedList = null;
            if(pointer1.NodeValue.CompareTo(pointer2.NodeValue) > 0)
            {
                mergedList = pointer2;
                pointer2 = pointer2.Next;                
            }
            else
            {
                mergedList = pointer1;
                pointer1 = pointer1.Next;
            }

            mergedList.Next = null;
            var pointer3 = mergedList;

            while(pointer1 != null && pointer2 != null)
            {
                if(pointer1.NodeValue.CompareTo(pointer2.NodeValue) > 0)
                {
                    pointer3.Next = pointer2;
                    pointer2 = pointer2.Next;
                }
                else
                {
                    pointer3.Next = pointer1;
                    pointer1 = pointer1.Next;
                }

                pointer3 = pointer3.Next;
                pointer3.Next = null;
            }

            if(pointer1 != null)
            {
                pointer3.Next = pointer1;
            }

            if(pointer2 != null)
            {
                pointer3.Next = pointer2;
            }

            return mergedList;
        }
    }
}