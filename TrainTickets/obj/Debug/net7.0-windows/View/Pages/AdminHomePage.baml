   M S B A M L   `   `   `  ����G  CTrainTickets, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:TrainTickets.View.PagesTrainTickets.View.Pages  5      +    %TrainTickets.View.Pages.AdminHomePage   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:TrainTickets.View.Pages     5        N� Title$  AdminHomePage��5	      .��5      � 
������� � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��9* �6   �� 5      $��1* �6   .+�5   
   �� $��Medium"�5      $��13(�5      $��0, 10, 0, 0q�5      $	��Top=�5      $��Center=�5      $��0��5      �� 5      
���   �$��SemiBold"�5       �� TextDecorations$
 None{�5       �� Command 5      �� *NavigationToSignInPageCommand+.�6K   
Выйти5      5      �� 5!   
   $��Center=�5"      $��Center=�5#      $��1��5$      .+�5&      �� $%��Добавить станцию��5'      $
��Left=�5(      $	��Top=�5)      $	��300��5*      $��50��5+      $��0, 0, 0, 26q�5,      
���������5.      �� *&$NavigationToStationAddingPageCommand+�� 50      $#��Удалить станцию��51      $
��Left=�52      $	��Top=�53      $	��300��54      $��50��55      $��0, 0, 0, 26q�56      
���������58      �� *(&NavigationToStationDeletingPageCommand+�� 5:      $%��Добавить маршрут��5;      $
��Left=�5<      $	��Top=�5=      $	��300��5>      $��50��5?      
�������$��0 0 0 26q�5A      ��5B      �� *$"NavigationToRouteAddingPageCommand+�� 5D      $/��)Редактировать маршрут��5E      $
��Left=�5F      $	��Top=�5G      $	��300��5H      $��50��5I      
���������5K      �� *&$NavigationToRouteDeletingPageCommand+5M      5O      5P      