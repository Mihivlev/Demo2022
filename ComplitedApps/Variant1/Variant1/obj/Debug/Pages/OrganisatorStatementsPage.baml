   M S B A M L   `   `   `  ����C  ?Variant1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Variant1.PagesVariant1.Pages  5      .    (Variant1.Pages.OrganisatorStatementsPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:Variant1.Pages     5      -   5          N� Title$  OrganisatorStatementsPage��5	       N� 
Background
 �����.��5      �  � RowDefinitions 5      �� 5      $
��auto �6   �� 5      .+�5      ��    
BaseBorder#��[  6   ._�5      � .+�5      �� $��Заявки��6   $��20(�5   
   $
��Left=�5   
   �� 5       �� Orientation$ 
Horizontal=�6   $��Right=�5      .+�5      �� $��Наименование��6   �� 5       .+�5!      �� -   5        $��
SearchText��5!      $	��250��5"   
   5#   
   �� 5$      5%      5&      5'      5(      �� 5,      -   5        $��LVStatement��5,      $��1��5-      $��	20 0 20 0q�5.      ��50      �� 51      .R�52      �� -   5        #��[  52      ._�53      �  � ColumnDefinitions 54   	   �� 55   
   $��2* �6   �� 56   
   �� 57   
   $��2* �6    59   	   �� 5:   
   $
��auto �6   �� 5;   
   .+�5@   	   �� $
��Left=�5A      ��5@      �� *Activities.Activity+ �� StringFormat$ Заявка на {0}��5A      �� 5E   	   $��1��5F      ��5E      �� *!Activities.TimeForActivity.Time+$" Время начала: {0}��5F      �� 5J   	   $��2��5K      ��5J      �� *Activities.Users.FIO+$ Заявитель: {0}��5K      5L   	   5M      5N      5P      5Q      5R      