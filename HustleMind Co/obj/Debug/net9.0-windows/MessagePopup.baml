   M S B A M L   `   `   `  ����  HustleMind Co.!    HustleMind_Co_.MessagePopup   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Message��5   	   $	��300��6   $	��400��6&    � WindowStartupLocation$ CenterScreen=�5   	    � ShowInTaskbar$ False��6.    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�6   
������  � AllowsTransparency$
 True��5   "   .��5      � .+�5	   
   �� -   5         ��Name$ 
MainBorder��5	      
����������	#FF160078$��5q�6P    �� CornerRadius$ 20��6d    �� Padding$ 10q�6v   ._�5
      � .+�5      �� 
�������$ 20��6,   $ 20q�6>   ._�5      � 	 � RowDefinitions	 5      �� 5      $��2* �6,   �� 5      $��1* �6,   �� 5      $
��Auto �6,   .+�5      �� -   5        
 ��Name$
 messageIcon��5       $��0��65   $	��140��6B   $	��140��6N   $��Center=�5       $��Center=�6=   $0��*pack://application:,,,/Assets/Ok-amico.png��5       �� 5      -   5         ��Name$ MessageText��5   $   $��1��69    �� TextAlignment$ Center=�6F   $��Center=�5   $   $��Center=�6?   $��	20,0,20,0q�5   $   $��16(�67   $
��Wrap=�5   $   $
��Bold"�68   �� 5      $��2��6%    �� Orientation$ 
Horizontal=�62   $��Center=�6K   .+�5      �� -   5         ��Name$ okButton��5   %   $��OK��67   $	��100��6D   $��35��6P   $��	0,10,5,10q�6\   ���	#FF160078
����������	#FF160078$��2q�5!   L   $
��Bold"�5"   !   �� 5#      -   5        $ cancelButton��5#   %   $��Cancel��6;   $	��100��6L   $��35��6X   $��	5,10,0,10q�6d   
�������
�������
�������$��2q�5%   G   $
��Bold"�5&   !   $y�	Collapsed=�63   5'      5)      5*      5+      5,      5-      5.      