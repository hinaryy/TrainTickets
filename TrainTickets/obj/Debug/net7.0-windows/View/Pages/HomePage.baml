   M S B A M L   `   `   `  ����G  CTrainTickets, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:TrainTickets.View.PagesTrainTickets.View.Pages  5      &     TrainTickets.View.Pages.HomePage   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:TrainTickets.View.Pages     5        N� Title$  HomePage��5	      .��5      � 
������� � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��9* �6   �� 5      $��1* �6   .+�5   
   �� $��Medium"�5      $��13(�5      $��0, 10, 0, 0q�5      $	��Top=�5      $��Center=�5      $��0��5      �� 5      
���   �$��SemiBold"�5       �� TextDecorations$
 None{�5       �� Command 5      �� *NavigationToSignInPageCommand+.�6K   
Выйти5      5      �� 5!   
   $��2��5"      $��Баланс��5#      $��Center=�5$      $��SemiBold"�5%      $��0 10 0 0q�5&      �� 5)   
   $��2��5*      $��Center=�5,      $��0, 30, 0, 0q�5-      ��5+      �� *	Balance+ �� UpdateSourceTrigger$ PropertyChanged=�5/      �� 51   
   $��2��52      $��Center=�53      $��0 43 0 0q�54      �� 55      
�������$
 None{�57       58      �� *'%OpenBalanceReplenishmentWindowCommand+.�6K   пополнить5;      5<      �� 5>      $��Center=�6   $��0, 50, 0, 0q�66   $��1��6K   .+�5@      �� $��Купить билет��5A      $
��Left=�5B      $	��Top=�5C      $	��300��5D      $��50��5E      $��0, 0, 0, 20q�5F      
���������5H      �� *'%NavigationToTicketPurchasePageCommand+�� 5J      $��Мои билеты��5K      $
��Left=�5L      $	��Top=�5M      $	��300��5N      $��50��5O      $��0, 0, 0, 20q�5P      
���������5R      �� *$"NavigationToUserTickersPageCommand+5U      5W      5Y      