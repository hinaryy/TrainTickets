   M S B A M L   `   `   `  ����  TrainTickets(    "TrainTickets.View.Pages.SignInPage   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  
SignInPage��5      .��5
      � 
������� � RowDefinitions 5   
   �� 5      �� 5      $	��360 �6   �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      $	��360 �6   �� 5      .+�5   
   �� $��1��6   $��1��6!   $��1q�6.   
���   � �� CornerRadius$ 3��6V   ._�5      �� .+�5      �� $
��Bold"�5      $��25(�5      $��Center=�5      $��	0,30,0,30q�5         Poppins Bold#��[  5      $��Авторизация��6<   �� 5       $��
Логин��5!      $��	30 0 30 0q�5"      �� 5#      $��Center=�5%      $��50��5&      $	��300��5'      
���   �$��Center=�5)      $��10 0 0 0q�5*      ��5$      �� *Name+ �� UpdateSourceTrigger$ PropertyChanged=�5*      �� 5-      $��Пароль��5.      $��	30 0 30 0q�5/      �� 50      $��Center=�52      $��50��53      $	��300��54      
���   �$��Center=�56      $��10 0 0 0q�57      ��51      �� *
Password+ �� Mode$ TwoWay=�$ PropertyChanged=�57      �� 59      $��30, 5, 30, 5q�5;      
���  ����5:      �� *ErrorMessage+$ TwoWay=�$ PropertyChanged=���5?      �� 5@       �� 
TargetType" ��6     �� Triggers 5A      �� 5B   "    �� Binding 6.   �� 	 �� ElementName$	 ErrorMessage��
 �� Path$

 Text� �� Value  6f   .a�5C   &   ��  �� Property � �� �� Value$ 0��6?   5D   #   �� 5E   "    6.   �� $	 ErrorMessage��$

 Text�; 7Пароль или логин некорректный6f   .a�5F   &   ��  � ��$ 20��6?   5G   #   5I      5L      �� 5N      $��Center=�5O      $��50��5P      $	��150��5Q      $��
Войти��5R      ���#fff
���   �$��1q�5U      $��DemiBold"�5V      $��13(�5W      ��5X      �� *SignInCommand+�� 5[      $��Medium"�5\      $��13(�5]      $��Center=�5^      $��0, 10, 0, 0q�5_      �� 5a      
���   �$��SemiBold"�5b        �� TextDecorations$
 None{�5c        �� Command 5d       �� *NavigationToSignUpCommand+.�6N   &$Зарегистрироваться5f      5g      5i      5j      5k      5l      