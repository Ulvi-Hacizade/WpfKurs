   M S B A M L   `   `   `  ���� 
  DOC-21+    %DOC_21.Views.Windows.SqlConfiguration   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006       � Title$  Sql Konfiqurasiyası��$	��300��$	��400��
������  � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � AllowsTransparency .  � 	Resources  �� 
TargetType   btnGreen �� Property �� Value	 �� 
TargetType
 �� CornerRadius �� Padding �� Triggers P� Property P� Value 
 btnRed ��Name ��Name �� Triggers �� 
TargetName �� 
Background � Cursor �� Bullet  MyBorderStyle��%:	  &	        &	 I    '�� �    'G� �    '	� �    &	 �    �� " ��.���  � �� �#fff��  � �� �#000��  � ��$ 15(���  � ��$ 5q���  � ��$ 5q���  � �� �� "	 ��.R��� #��z��$
 5��$	��1.1q�$ 5q����#000._��� $��Center=�$��Center=� P�  �@J�IsMouseOver . . ���  � ��
 � � ���  � �� �#fff�� " ��.���  � �� �#fff��  � �� �#000��  � ��$ 15(���  � ��$ 5q���  � ��$ 5q���  � �� �� "	 ��.R��� #��z��$
 5��$	��1.1q�$ 5q����#000._��� $��Center=�$��Center=� P�  �@J�IsMouseOver . . ���  � ��
 �  ����  � �� �#fff�� " ��.���  � ��$ 3q���  � ��$ 2q���  � �� �#000��  � ��$ 15(���  � ��$ 20����  � ��$	 250����  � ��$
 Bold"���  � �� �� "	 ��.R��� $ border��$
 5�����#000$	��1.1q����#fff._��� $ PART_ContentHost��|�.  $��Hidden=�$��Hidden=� P�  �@J�IsMouseOver . . ��� $ border�� � ��
 �  ����  � ��
 �  ����  � ��$
 Bold"�P�  �@J�	IsFocused . . ���  � ��
 ��  ��� $ border�� � ��
 ��  ��� " G�.���  � ��$ 3q���  � ��$ 2q���  � �� �#000��  � ��$ 15(���  � ��$ 20����  � ��$	 250����  � ��$
 Bold"���  � �� �� "	 G�.R��� $ border��$
 5�����#000$	��1.1q����#fff._��� $ PART_ContentHost��|�.  $��Hidden=�$��Hidden=� P�  �@J�IsMouseOver . . ��� $ border�� � ��
 �  ����  � ��
 �  ����  � ��$
 Bold"�P�  �@J�	IsFocused . . ���  � ��
 ��  ��� $ border�� � ��
 ��  ��� " 	�.���  � ��
 ���� ��  � �� �� "	 	�.R��� 
 ���� $
 Hand�� � $��16��$��16��.+��� $��
RadioOuter��
������ ���	#FF787878$��2q�$
 2���� $��	RadioMark��$
 0��$��4q����	#FF787878$y�Hidden=�._��� $��3,1,0,0q����	#FF3E3E3E
������ $��Calibri)�$��17(���  P�  �@d�	IsChecked$
 trueY�. ��� $ 	RadioMark�� � y�$ Visible=��� $ 
RadioOuter�� � �� �	#FFADADAD�� " ��.���  � ��
 �������  � ��$ 2q���  �@��CornerRadius$ 3��.���� $
 15�����	#FFEAEAEA._�� 
������ .+��� $��7q�$��Center=�.+�]� .+��� $��Server tipi��$	��130��$��17(�$��Center=��� ���� *ServerTypes+ �� SelectedItem �� *ConfigObject.ServerType+]� .+��� $��Server adı��$	��130��$��17(�$��Center=��� $��35������ *ConfigObject.ServerName+]� .+��� $��	Baza adı��$	��130��$��17(�$��Center=��� $��35������ *ConfigObject.DatabaseName+]� .+��� $��Bağlantı növü��$	��150��$��17(�$��Center=�	� -   $��	rbWindows��$��Center=�$��20(�$��Windows��
������  d� 	IsChecked �� *&$ConfigObject.IsWindowsAuthentication+	� -   $��rbSqlServer��$��Center=�$
��10,0q�$��
Sql Server��� ���� " �.���  � {� .  ��  �� Binding �� *&$ConfigObject.IsWindowsAuthentication+ �� Value True.a���  � {� .  .+��� .+�]� .+��� $��Login��$	��130��$��17(�$��Center=��� $��35������ *ConfigObject.UserId+]� .+��� $��Şifrə��$	��130��$��17(�$��Center=�G� -   $��txtPassword��$��35��]� $��Center=�$��0,15,0,0q�.+��� $	��120��$��Saxla��#��[  ���� *Save+����  �� ElementName$ txtPassword���� $	��120��$��İmtina��#��[ ���� *Cancel+