   M S B A M L   `   `   `  ����   HustleMind Co.&     HustleMind_Co_.Pages.PaymentPage   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006       N� Title$  PaymentPage��.���  � ColumnDefinitions �� $	��200 ��� $��* �.+��� $��0������  �� 
StartPoint$ 0.5,0&� �� EndPoint$ 0.5,1&�.���  � Color$ 	#FF7226FF�� � Offset$ 0Q�� $ 	#FF160078��$
 0.65Q�� $ 	#FF010030��$ 1Q�.+��� $	��120��$	��120��$��/Assets/jet.png��$��	0,20,0,10q�$��Center=��� 
������ $��0q�$��0,30,0,0q�$��Stretch=�$	��Top=�
�������$��16(�$��Poppins)� �� SelectionMode$ Single=� �� SelectedItem �� *SelectedMenuItem+.@��� -   $��15q� � Cursor$
 Hand��.���� 	 �� Orientation$	 
Horizontal=�$��Center=�.+��� $��Segoe MDL2 Assets)�$	����$��0,0,15,0q�$��20(��� $��	Dashboard��$��Center=�$��SemiBold"��� -   $��15q�$
 Hand��.���� $	 
Horizontal=�$��Center=�.+��� $��Segoe MDL2 Assets)�$	����$��0,0,15,0q�$��20(��� $��	Customers��$��Center=�$��SemiBold"��� -   $��15q�$
 Hand��.���� $	 
Horizontal=�$��Center=�.+��� $��Segoe MDL2 Assets)�$	����$��0,0,15,0q�$��20(��� $��Projects��$��Center=�$��SemiBold"��� -   $��15q�$
 Hand��.���� $	 
Horizontal=�$��Center=�.+��� $��Segoe MDL2 Assets)�$	����$��0,0,15,0q�$��20(��� $��Payments��$��Center=�$��SemiBold"��� -   $��15q�$
 Hand��.���� $	 
Horizontal=�$��Center=�.+��� $��Segoe MDL2 Assets)�$	����$��0,0,15,0q�$��20(��� $��Reviews��$��Center=�$��SemiBold"��� $	��120��
������ �� -   $��15q�$
 Hand��.���� $	 
Horizontal=�$��Center=�$��21��.+��� $��Segoe MDL2 Assets)�$	����$��0,0,15,0q�$��20(��� $��1��$��20q�$
��Auto=�
�������.���� .+��� $��Payment Information��$��24(�$
��Bold"�$��0,0,0,20q�$��Poppins)����#333�  �� $��* ��� $
��Auto �.+�� $	��588��$
��Left=�$��32,0,0,0q�
 � RowDefinitions
 �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto � �� $	��150 ��� $��* �.+��� $��Project ID:��$��0��$��0��$��Center=�$
��0,10q�$��Poppins)�$��SemiBold"�$��14(��� -    ��Name$ txtProjectId��$��0��$��1��$
��0,10q�$��10q����#DDD$��1q�$��Poppins)�$��SemiBold"�$��14(��� $��Payment Type:��$��1��$��0��$��Center=�$
��0,10q�$��Poppins)�$��SemiBold"�$��14(��� -    ��Name$ cmbPaymentType��$��1��$��1��$
��0,10q�$��10q����#DDD$��1q�$��Poppins)�$��SemiBold"�$��14(�.@��� $��Advance Payment���� $��Balance Payment���� $��Full Payment���� $��Amount:��$��2��$��0��$��Center=�$
��0,10q�$��Poppins)�$��SemiBold"�$��14(��� -	   $ 	txtAmount��$��2��$��1��$
��0,10q�$��10q����#DDD$��1q�$��Poppins)�$��SemiBold"�$��14(��� $��Payment Date:��$��3��$��0��$��Center=�$
��0,10q�$��Poppins)�$��SemiBold"�$��14(�(  "System.Windows.Controls.DatePicker  -
     Name$ dpPaymentDate��$��3��$��1��$
��0,10q�$��10q����#DDD$��1q�$��Poppins)�$��SemiBold"�$��14(��� $��Payment Status:��$��4��$��0��$��Center=�$
��0,10q�$��Poppins)�$��SemiBold"�$��14(��� -   $ cmbPaymentStatus��$��4��$��1��$
��0,10q�$��10q����#DDD$��1q�$��Poppins)�$��SemiBold"�$��14(�.@��� $
��Paid���� $��Pending���� $��Payment Method:��$��5��$��0��$��Center=�$
��0,10q�$��Poppins)�$��SemiBold"�$��14(��� -   $ cmbPaymentMethod��$��5��$��1��$
��0,10q�$��10q����#DDD$��1q�$��Poppins)�$��SemiBold"�$��14(�.@��� $��Online���� $	��ATM���� $
��Cash���� $��Attach File:��$��6��$��0��$��Center=�$
��0,10q�$��Poppins)�$��SemiBold"�$��14(��� -   $��Browse��$��6��$��1��$
��0,10q�$��10q����#DDD$��1q��� -    ��Name$ txtFileName��$��7��$��1��$
��0,10q� �� Padding$ 10q��� -   $ txtFilePath��$��8��$��0��$
��0,10q�$��10q����#DDD$��1q� �� 
IsReadOnly$
 True��$y�	Collapsed=��� $	 
Horizontal=�$��9��$��1��$��Center=�$��0,20,0,0q�.+��� -   $��Add Payment��$	��150��$��35��$��0,0,20,0q����#4A90E2
�������$��Poppins)����#357ABD�� -   $��Save Changes��$	��150��$��35�����#E74C3C
�������$��Poppins)����#C0392B�� $&�� /Assets/Selecting team-amico.png��$	��300��$��20,0,0,0q�$��Uniform=�$��1���� $��Payments List��$��24(�$
��Bold"�$��	0,20,0,20q�$��Poppins)����#333�� 
������� �� CornerRadius$ 12�����#E5E7EB$��1q� �� Padding$ 20q�$��20q� J� SnapsToDevicePixels$
 True��._�&   System.Windows.Controls.DataGrid  -     Name$ PaymentDataGrid��   AutoGenerateColumns$ False��   HeadersVisibility$ Column=�   CanUserAddRows$ False��   
IsReadOnly$
 True��   AlternatingRowBackground �#FAFAFA   GridLinesVisibility$
 None=�   	RowHeight$ 60Q�   ColumnHeaderHeight$ 50Q�$��Poppins)�$��14(�$��0q�
����������#374151   HorizontalGridLinesBrush �#E5E7EB   VerticalGridLinesBrush �#E5E7EB   ColumnHeaderStyle ��   �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"   .��� ! �� Property! � ��" �� Value" �#F9FAFB�� ! � ��" �#111827�� ! � ��$
" Bold"��� ! � ��$" 16(��� ! � ��" �#E5E7EB�� ! � ��$" 0,0,0,1q��� ! � ��$
" 10,0q��� ! � ��$
" Left=�#   	CellStyle# �� *  $System.Windows.Controls.DataGridCell"   .��� ! � ��" �#111827�� ! � ��$" 14(��� ! � ��$" SemiBold"��� ! � ��$
" 10,0q��� ! � ��$
" Left=��� ! � ��$" Center=�$   Columns$ 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn%   Header$% 
Payment ID��&   Width5  /System.Windows.Controls.DataGridLengthConverter$	& 120 1  +System.Windows.Controls.DataGridBoundColumn'   Binding' �� *	PaymentId+(   ElementStyle( �� "  ��.��� ! � ��$" Center=��� ! �@��Padding$" 5,0,0,0q�  $% 
Project ID��$	& 120 ' �� *	ProjectId+( �� "  ��.��� ! � ��$" Center=��� ! �@��Padding$" 5,0,0,0q�  $% Payment Type��$	& 160 ' �� *PaymentType+( �� "  ��.��� ! � ��$" Center=��� ! �@��Padding$" 5,0,0,0q�  $% Amount��$	& 150 ' �� *Amount+( �� "  ��.��� ! � ��$" Center=��� ! �@��Padding$" 5,0,0,0q�  $% Payment Date��$	& 200 ' �� *PaymentDate+) �� StringFormat$) {0:yyyy-MM-dd}��( �� "  ��.��� ! � ��$" Center=��� ! �@��Padding$" 5,0,0,0q�4	  .System.Windows.Controls.DataGridTemplateColumn	  $% Status��$	& 200 * 	  CellTemplate* �� .R��� $ 12��$	 6,3q�$��90��$
��Left=�$��Center=����� "  ��.��� ! � ��
" ������� ! � ��
" ���� �� ! � ��$" 1q�+ �� Triggers+ �� , �� Binding, �� *PaymentStatus+- �� Value- Paid.a��� ! � ��" �#A5D6A7�� ! � ��" �#43A047�� , �� *PaymentStatus+- Pending.a��� ! � ��" �#FFCCCB�� ! � ��" �#F44336._��� 
���   �$��SemiBold"�$��12(�$��Center=�$��Center=����� *PaymentStatus+  $% Payment Method��$	& 160 ' �� *PaymentMethod+( �� "  ��.��� ! � ��$" Center=��� ! �@��Padding$" 5,0,0,0q�	  $% 	File Path��$	& 250 * �� .R�� .+��� $
��Wrap=�$��CharacterEllipsis=�$��Poppins)�$��14(����#111827$	 5,0q�$��40��. �� LineStackingStrategy$. BlockLineHeight=�/ �� 
LineHeight$/ 20��0 �� TextAlignment$
0 Left=����� *
FilePath+	  $% Download��$	& 100 * �� .R�� $��Center=�$��Center=�.+��� $	 
Horizontal=�$��Center=�$��Center=�.+��� -   $��32��$��32��$��4q����#EFF6FF���#3B82F6$��1q�1 � ToolTip$1 Download��.���� $!��/Assets/cloud-computing.png��$��16��$��16��	  $% Actions��$	& 120 * �� .R�� $��Center=�$��Center=�.+��� $	 
Horizontal=�$��Center=�$��Center=�.+��� -   $��32��$��32��$��4q����#ECFDF5���#34D399$��1q�$
1 Edit��.���� $��/Assets/pencil.png��$��16��$��16���� -   $��32��$��32��$��4q����#FEF2F2���#F87171$��1q�$1 Delete��.���� $��/Assets/bin.png��$��16��$��16��