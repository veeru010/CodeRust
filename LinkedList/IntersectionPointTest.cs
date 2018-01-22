using System;

namespace CodeRust.LinkedList
{
  public static class IntersectionPointTest
  {
    public static void Run()
    {
      ListNode<int> head1 = new ListNode<int>(29);
      ListNode<int> node1 = new ListNode<int>(23);
      head1.Next = node1;
      ListNode<int> node2 = new ListNode<int>(82);
      node1.Next = node2;
      ListNode<int> node3 = new ListNode<int>(11);
      node2.Next = node3;
      ListNode<int> node4 = new ListNode<int>(12);
      node3.Next = node4;
      ListNode<int> node5 = new ListNode<int>(27);
      node4.Next = node5;

      ListNode<int> head2 = new ListNode<int>(13);
      ListNode<int> node21 = new ListNode<int>(4);
      head2.Next = node21;
      node21.Next = node4;
      Console.WriteLine("First List");
      head1.Display();
      Console.WriteLine("Second List");
      head2.Display();

      IntersectionPoint ip = new IntersectionPoint();
      var inode = ip.Find<int>(head1,head2);
      Console.WriteLine($"Intersection {inode?.NodeValue}");
    }
  }

  public class IntersectionPoint
  {
    public ListNode<T> Find<T>(ListNode<T> head1,ListNode<T> head2)
    {
      if(head1 == null || head1.Next == null || head2 == null || head2.Next == null) return null;
      var pointer1 = head1;
      var pointer2 = head2;
      int iterationCount = 0;

      while(iterationCount <= 2 && pointer1 != pointer2)
      {
        if(pointer1 == null)
        {
          pointer1 = head2;
          iterationCount++;
        }

        if(pointer2 == null)
        {
          pointer2 = head1;
          iterationCount++;
        }

        pointer1 = pointer1.Next;
        pointer2 = pointer2.Next;
      }

      return (pointer1 == pointer2) ? pointer1 : null;
    }
  }
}