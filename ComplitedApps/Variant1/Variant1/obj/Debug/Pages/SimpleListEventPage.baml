   M S B A M L   `   `   `  ����C  ?Variant1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Variant1.PagesVariant1.Pages  5      (    "Variant1.Pages.SimpleListEventPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:Variant1.Pages     5        N� Title$  SimpleListEventPage��5	      .��5      �  � RowDefinitions 5      �� 5      $
��auto �6   �� 5      .+�5      ��    
BaseBorder#��[  6   ._�5      � .+�5      �� $��Мероприятия��6   $
��Left=�6#   �� 5       �� Orientation$ 
Horizontal=�6   $��Right=�6*   .+�5      �� $��Напрвление��6   �� 5      -   5        $��CBDirections��5       �� SelectedIndex$ 0��5   
    �� DisplayMemberPath$ 	Direction��5   
   $	��300��5   
   $��5q�6   �� 5      $��     Дата��6   (  "System.Windows.Controls.DatePicker  5      -   5        $��	DPForList��5      $��0q�5   	   $��5q�5   	   $��18(�6   5       5!      5"      �� 5$      -   5        $��LVEvents��5$      $��1��6   $��0q�6)   $��Disabled=�5%      $��Center=�5&      ��5(      �� 5)      .R�5*      �� #��[  6   $	��300��62   ._�5+      �� .+�5,   	   �� ��6   �� *Photo+�� 5-   	   $
��Wrap=�5.      ��5-      �� *Event+5.      � 5/   	   .+�50   
   �� $
��Left=�51      ��50      �� *Directions.Direction+51      �� 52   
   $��Right=�53      ��52      �� *Date+ �� StringFormat$ {0:dd.MM.yyyy}��53      54   
   �� 55   	   -   5          
BaseButton#��[ 55      ._�57   
   �� ��6   �� *	Connect+58   
   59   	   5:      5;      ��5=      �� 5>      .R�5?      � 5@      5B      5C      5D      