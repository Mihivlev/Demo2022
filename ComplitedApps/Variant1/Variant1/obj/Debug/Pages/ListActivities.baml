   M S B A M L   `   `   `  ����C  ?Variant1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Variant1.PagesVariant1.Pages  5      #    Variant1.Pages.ListActivities   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:Variant1.Pages     5      -   5          N� Title$  ListActivities��5	       N� 
Background
 �����.��5      �  � RowDefinitions 5      �� 5      $
��auto �6   �� 5      .+�5      ��    
BaseBorder#��[  6   ._�5      � .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� -   5          
BaseButton#��[ 5      ._�5      �� $	�� + ��6   $��25(�6   5      �� 5      $��Активности��6   $��20(�5      $
��Left=�5      5      �� 5#      $ 
Horizontal=�6   $��Right=�5$      .+�5&      �� $��Наименование��6   �� 5'      .+�5(      �� -   5        $��
SearchText��5(      $	��250��5)   
   5*   
   �� 5+      5,      �� 5.      $��     Модератор��6   �� 5/      -   5        $��CBModerators��5/      $	��350��6$    �� SelectedIndex$ 0��50   
    �� DisplayMemberPath$	 FIO��51   
   52   
   53      54      55      �� 59      -   5        $��
LVActivity��59      $��1��5:      $��	20 0 20 0q�5;      ��5=      �� 5>      .R�5?      �� -   5        #��[  5?      ._�5@      �  � ColumnDefinitions 5A   	   �� 5B   
   $��2* �6   �� 5C   
   �� 5D   
   $��2* �6   .+�5H   	   �� $
��Left=�5I      ��5H      �� *
Activity+5I      �� 5L   	   $��1��5M      $
��Left=�5N      ��5L      �� *TimeForActivity.Time+ �� StringFormat$" Время начала: {0}��5N      �� 5Q   	   $��2��5R      $
��Left=�5S      ��5Q      �� *	Users.FIO+$ Модератор: {0}��5S      5T   	   5U      5V      5X      5Y      5Z      