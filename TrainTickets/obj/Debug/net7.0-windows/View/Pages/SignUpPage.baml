   M S B A M L   `   `   `  ����G  CTrainTickets, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:TrainTickets.View.PagesTrainTickets.View.Pages  5      ?$clr-namespace:TrainTickets.ViewModelTrainTickets.ViewModel  5      (    "TrainTickets.View.Pages.SignUpPage   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:TrainTickets.View.Pages     5      :	ViewModel$clr-namespace:TrainTickets.ViewModel     5        N� Title$  
SignInPage��5
      .��5      � 
������� � RowDefinitions 5   
   �� 5      �� 5      $	��440 �6   �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      $	��360 �6   �� 5      .+�5   
   �� $��1��6   $��1��6!   $��1q�6.   
���   � �� CornerRadius$ 3��6V   ._�5      �� .+�5      �� $
��Bold"�5      $��25(�5      $��Center=�5      $��	0,30,0,30q�5         Poppins Bold#��[  5       $��Регистрация��6<   �� 5"      $��
Логин��5#      $��	30 0 30 0q�5$      �� 5%      $��Center=�5'      $��50��5(      $	��300��5)      
���   �$��Center=�5+      $��10 0 0 0q�5,      ��5&      �� *Name+ �� UpdateSourceTrigger$ PropertyChanged=�5,      �� 50      $��E-mail��51      $��	30 0 30 0q�52      �� 53      $��Center=�55      $��50��56      $	��300��57      
���   �$��Center=�59      $��10 0 0 0q�5:      ��54      �� *Email+$ PropertyChanged=�5:      �� 5<      $��Пароль��5=      $��	30 0 30 0q�5>      �� 5?      $��Center=�5A      $��50��5B      $	��300��5C      
���   �$��0 0 0 30q�5E      $��Center=�5F      $��10 0 0 0q�5G      ��5@      �� *
Password+ �� Mode$ TwoWay=�$ PropertyChanged=�5G      �� 5I      $��Center=�5J      $��50��5K      $	��150��5L      $*��$Зарегистрироваться��5M      ���#fff
���   �$��1q�5P      $��DemiBold"�5Q      $��13(�5R      ��5S      �� *SignUpCommand+�� 5V      $��Medium"�5W      $��13(�5X      $��Center=�5Y      $��0, 10, 0, 0q�5Z      �� 5\      
���   �$��SemiBold"�5]        �� TextDecorations$
 None{�5^        �� Command 5_       �� *NavigationToSignInCommand+.�6N   
Войти5a      5b      5d      5e      5f      5g      