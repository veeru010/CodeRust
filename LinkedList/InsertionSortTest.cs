using System;

namespace CodeRust.LinkedList
{
  public static class InsertionSortTest
  {
    public static void Run()
    {
      ListNode<int> head = new ListNode<int>(7);
      ListNode<int> node1 = new ListNode<int>(14);
      head.Next = node1;
      ListNode<int> node2 = new ListNode<int>(28);
      node1.Next = node2;
      ListNode<int> node3 = new ListNode<int>(28);
      node2.Next = node3;
      ListNode<int> node4 = new ListNode<int>(28);
      node3.Next = node4;
      ListNode<int> node5 = new ListNode<int>(14);
      node4.Next = node5;
      ListNode<int> node6 = new ListNode<int>(21);
      node5.Next = node6;
      Console.WriteLine("Input :");
      head.Display();
      Console.WriteLine("After Sorting :");
      head.Sort().Display();
    }
  }
}