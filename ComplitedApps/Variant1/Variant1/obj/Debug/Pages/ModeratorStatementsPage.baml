   M S B A M L   `   `   `  ����C  ?Variant1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Variant1.PagesVariant1.Pages  5      ,    &Variant1.Pages.ModeratorStatementsPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:Variant1.Pages     5        N� Title$  ModeratorStatementsPage��5	       N� 
Background
 �����.��5      �  � RowDefinitions 5      �� 5      $
��auto �6   �� 5      .+�5      ��    
BaseBorder#��[  6   ._�5      � .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� -   5          
BaseButton#��[ 5      ._�5      �� $	�� + ��6   $��25(�6   5      �� 5      $��Заявки��6   $��20(�5      $
��Left=�5      5      �� 5      $ 
Horizontal=�6   $��Right=�5      .+�5      �� $��Наименование��6   �� 5       .+�5!      �� -   5        $��
SearchText��5!      $	��250��5"   
   5#   
   �� 5$      5%      5&      5'      5(      �� 5*      -   5        $��LVStatement��5*      $��1��5+      $��	20 0 20 0q�5,      ��5.      �� 5/      .R�50      �� -   5        #��[  50      ._�51      �  � ColumnDefinitions 52   	   �� 53   
   $��2* �6   �� 54   
    56   	   �� 57   
   $
��auto �6   �� 58   
   .+�5;   	   �� $
��Left=�5<      ��5;      �� *Activities.Activity+ �� StringFormat$ Заявка на {0}��5<      �� 5>   	   $��1��5?      ��5>      �� *!Activities.TimeForActivity.Time+$" Время начала: {0}��5?      �� 5A   	   5B   	   5C      5D      5F      5G      5H      