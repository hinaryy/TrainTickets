   M S B A M L   `   `   `  ����G  CTrainTickets, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:TrainTickets.View.PagesTrainTickets.View.Pages  5      /    )TrainTickets.View.Pages.RouteDeletingPage   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:TrainTickets.View.Pages     5        N� Title$  RouteDeletingPage��5	      .��5      � 
������� � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��9* �6   �� 5      $��1* �6   .+�5   
   �� $��Medium"�5      $��13(�5      $��0, 10, 0, 0q�5      $	��Top=�5      $��Center=�5      $��0��5      �� 5      
���   �$��SemiBold"�5       �� TextDecorations$
 None{�5       �� Command 5      �� *" NavigationToAdminHomePageCommand+.�6N   
Назад5      5      �� 5    
   $��Center=�5!      $��Center=�5"      $��1��5#       �� Orientation$ 
Horizontal=�5$      .+�5&      �� $	��350��5'      $��Center=�5(      $��Center=�5)      $��1��5*      .+�5,      �� $��250px��5-      $��
0, 0, 0, 0q�5.         	RouteCard#��[  51      ��5/      �� *Routes+ �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem 50      �� *SelectedRoute+$ PropertyChanged=�51      �� 54      $#��Удалить маршрут��55      
�������$��	0 26 0 0 q�57      $��30��58      ��59      �� *DeleteRouteCommand+5;      �� 5<      $	��150��5=      $��26 0 0 0q�5>      $��Center=�5?      $	��Top=�5@      .+�5B      �� $��Откуда:��6   $��0 1 0 0q�6*   �� 5C      $��30��5F      $��0 0 0 8q�5G      ��5D      �� *
Stations+ �� Text 5E      �� *FromStation+$ PropertyChanged=�5G      �� 5M      $��	Куда:��6   �� 5N      $��30��5Q      $��0 0 0 8q�5R      ��5O      �� *
Stations+ 5P      �� *	ToStation+$ PropertyChanged=�5R      �� 5W      $��Дата��6   (  "System.Windows.Controls.DatePicker  5X         SelectedDate 
01/01/20235Z      $��30��5[      
�������$��0 0 0 8q�5]      	   Text	 5Y      �� *Date+
 �� Mode$
 TwoWay=�$ PropertyChanged=�5]      �� 5b      $��Цена��6   �� 5c      $��30��5d      $��0 0 0 0q�5e      ��5f      �� *Price+$ PropertyChanged=��� 5h      $��Сохранить��5i      
�������$��30��5k      $��0 26 0 0q�5l      ��5m      �� *SaveEditedRouteCommand+5q      5r      5s      5t      