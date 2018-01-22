using System;

namespace CodeRust.LinkedList
{
  public static class MergeSortedListTest
  {
    public static void Run()
    {
      ListNode<int> head1 = new ListNode<int>(4);
      ListNode<int> node1 = new ListNode<int>(8);
      head1.Next = node1;
      ListNode<int> node2 = new ListNode<int>(12);
      node1.Next = node2;
      ListNode<int> node3 = new ListNode<int>(15);
      node2.Next = node3;
      ListNode<int> node4 = new ListNode<int>(19);
      node3.Next = node4;

      Console.WriteLine("First Line");
      head1.Display();

      ListNode<int> head2 = new ListNode<int>(7);
      ListNode<int> node21 = new ListNode<int>(9);
      head2.Next = node21;
      ListNode<int> node22 = new ListNode<int>(10);
      node21.Next = node22;
      ListNode<int> node23 = new ListNode<int>(16);
      node22.Next = node23;

      Console.WriteLine("Second Line");
      head2.Display();

      MergeSortedList ml = new MergeSortedList();
      var headNode = ml.Merge<int>(head1,head2);
      Console.WriteLine("Merged List");
      headNode.Display();
    }
  }

  public class MergeSortedList
  {
    public ListNode<T> Merge<T>(ListNode<T> head1,ListNode<T> head2) where T : IComparable<T>
    {
      if(head1 == null) return head2;
      if(head2 == null) return head1;
      ListNode<T> mergedList = null;
      ListNode<T> pointer3 = null;

      var pointer1 = head1;
      var pointer2 = head2;

      while(pointer1 != null && pointer2 != null)
      {
        if(pointer1.NodeValue.CompareTo(pointer2.NodeValue) > 0)
        {
          if(pointer3 == null)
          {
            mergedList = pointer2;
            pointer3 = pointer2;
          }
          else
          {
            pointer3.Next = pointer2;
            pointer3 = pointer3.Next;
          }

          pointer2 = pointer2.Next;
        }
        else
        {
          if(pointer3 == null)
          {
            mergedList = pointer1;
            pointer3 = pointer1;
          }
          else
          {
            pointer3.Next = pointer1;
            pointer3 = pointer3.Next;
          }

          pointer1 = pointer1.Next;
        }

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