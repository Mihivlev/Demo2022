   M S B A M L   `   `   `  ����C  ?Variant1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Variant1.PagesVariant1.Pages  5      )    #Variant1.Pages.ListParticipantsPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:Variant1.Pages     5      -   5          N� Title$  ListParticipantsPage��5	       N� 
Background
 �����.��5      �  � RowDefinitions 5      �� 5      $
��auto �6   �� 5      .+�5      ��    
BaseBorder#��[  6   ._�5      � .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� -   5          
BaseButton#��[ 5      ._�5      �� $	�� + ��6   $��25(�6   5      �� 5      $��Участники��6   $��20(�5      $
��Left=�5      5      �� 5      $ 
Horizontal=�6   $��Right=�5      .+�5       �� $��ФИО��6   �� 5!      .+�5"      �� -   5        $��
SearchText��5"      $	��250��5#   
   5$   
   �� 5%      5&      �� 5'      $!��     Мероприятие��6   �� 5(      -   5        $��CBEvents��5(      $	��250��6     �� SelectedIndex$ 0��5)   
    �� DisplayMemberPath$ Event��5*   
   5+   
   5,      5-      5.      �� 50      -   5        $��LVParticipants��50      $��1��51      $��	20 0 20 0q�52      ��54      �� 55      .R�56      �� -   5        #��[  56      ._�57      � .+�58   	   �� $ 
Horizontal=�6   .+�59   
   �� $��70��6)   ��6   �� *Photo+6)   �� 5:   
   ��6   �� *FIO+5;   
   �� 5=   	   ��6   �� *Email+�� 5?   	   $��Right=�6/   ��6   �� *
Roles.Role+6/   5@   	   5A      5B      5D      5E      5F      