   M S B A M L   `   `   `  ����@  <Mii_3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Mii_3Mii_3  5   	       Mii_3.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Mii_3     5   	     � Title$  
MainWindow��5   	   $	��500��6   $
��1000��6)    � 
ResizeMode$ NoResize=�66   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��600 �6   6-   �� 5      $	��400 �6   6-   .+�5   
   �� -   5         ��Name$ canvas��5   H   $��0��6   $	��585��6!   $
��Left=�6-   5      � 5   
   $��1��6    � RowDefinitions 5      �� 5      $	��350 �6    6/   �� 5      $	��150 �6    6/   .+�5      �� -   5        $��listBox��5   =   $	��380��6   $
��Left=�6"    �� SelectionMode$ Multiple=�6L   ��5      �� 5      .R�5      ��  �� Orientation$ 
Horizontal=�6%   $��3q�6>   .+�5      �� $��14(�6=   ��6$   �� *Name+��6K   �� *Color+5      5      5      � 5      $	��120��6   $	��Top=�6    $��1��68   .+�5       �� -   5         ��Name$ buttonCreate��5       $��25��6/   $	��100��6;   $��10q�6G   $	��Top=�6S   $
��Left=�6k   .��6�   Create6�   �� 5!      -   5        $ 
buttonEdit��5!      $��25��6-   $	��100��69   $��10 50 10 10q�6E   $	��Top=�6Z   $
��Left=�6r   .��6�   Edit6�   �� 5"      -   5        $ buttonDelete��5"      $��25��6/   $	��100��6;   $��10 85 10 10q�6G   $	��Top=�6\   $
��Left=�6t   .��6�   Delete6�   �� 5#      -   5        $ 
buttonUnit��5#      $��25��6-   $	��100��69   $��120 10 10 10q�6E   $	��Top=�6[   $
��Left=�6s   .��6�   Unit6�   �� 5$      -   5        $ buttomVr��5$      $��25��6+   $	��100��67   $��120 50 10 10q�6C   $	��Top=�6Y   $
��Left=�6q   .��6�   VR6�   5%      5&      5'      5(      