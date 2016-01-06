Public Class glos

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Label1.Text = ListBox1.SelectedItem
        Select Case ListBox1.SelectedIndex
            Case 0
                Label2.Text = "it is an 8-bit buffer register that stores intermediate results during a computer run. It is always one of the operands of ADD, SUB and OUT instructions."
            Case 1
                Label2.Text = "mnemonic for Add RAM data into accumulator and its OPCODE is 0001."
            Case 2
                Label2.Text = "SAP-1 uses a 2's-complement adder subtracter.SAP-1 uses a 2's-complement adder-subtractor. This module is asynchronous, which means that its contents can change as soon as the input word changes."
            Case 3
                Label2.Text = "is a program that takes basic computer instructions and converts them into a pattern of bits that the computer's processor can use to perform its basic operations."
            Case 4
                Label2.Text = "it is 8-bit buffer register which is primarily used to hold the other operand of mathematical operations. A low LB and positive clock edge load the word on the W bus into the B register. The two-state output of the B register drives the adder-subtractor, supplying the number to be adder or subtracted from the contents of the accumulator."
            Case 5
                Label2.Text = "it is a row of eight LEDs to show the contents of output register. Because each LED connects to one flip flop of the output port, the binary display shows us the contents of the output port. Therefore, after we’ve transferred an answer from the accumulator to the output port, we can see the answer in Binary form."
            Case 6
                Label2.Text = "it generates the control signals for each block so that action occurs in desired sequence. The lower left block contains the Controller Sequencer Unit. This resets the program counter to 0000 and wipes out the last instruction in the Instruction Register.A clock signal CLK is sent to all buffer registers; this synchronizes the operation of the computer, ensuring that things happen when they are supposed to happen. Meaning, all registers transfer occurs in the positive edge of a common. Controller sequencer is a 12-bit word comes out of the Controller- Sequencer block. This control word determines how the registers will react to the next positive CLK edge.
            Case 7
                Label2.Text = "is hardware or software or both that duplicates the functions of one computer system (the guest) in another computer system (the host), different from the first one, so that the emulated behavior closely resembles the behavior of the real system (the guest)."
            Case 8
                Label2.Text = "is the first part of the instruction cycle. During the fetch cycle, the address is sent to the memory, the program counter is incremented, and the instruction is transferred from the memory to the instruction register."
            Case 9
                Label2.Text = "mnemonic for stop processing and its OPCODE is 1110."
            Case 10
                Label2.Text = "This includes the address and switch registers. This switch registers which are part of the input unit allow you to send an address bits to the RAM. 	During a computer run, the address in the PC is latched in Memory Address Register (MAR)."
            Case 11
                Label2.Text = "The instruction register is the part of the control unit. To fetch an instruction from the memory the computer does a memory read operation. This places the contents of the addressed memory location on the W bus. At the same time, the instruction register is set up for loading on the next positive clock edge. The content of the instruction register are split into two nibbles. The upper nibble goes directly to the block Controller – Sequencer. The lower nibble is read onto the W bus when needed. IR contains the instruction, composed of OPCODE + ADDRESS, to be executed by SAP-1 computer."
            Case 12
                Label2.Text = "mnemonic for Load RAM data into accumulator with and its OPCODE is 0000."
            Case 13
                Label2.Text = "A program counter is a register in a computer processor that contains the 	address (location) of the instruction being executed at the current time.	It counts from 0000 to 	1111 and it signals the memory address of next instruction to be fetched and executed."
            Case 14
                Label2.Text = "the program code to be executed and data for SAP-1 computer is stored here. During a computer run, the RAM receives 4-bit addresses from MAR and a read operation is preformed. Also, the instruction or data word stored in RAM in placed on W bus for use of other part of the computer."
            Case 15
                Label2.Text = "mnemonic for Subtract RAM data into accumulator and its OPCODE is 0010."
            Case 16
                Label2.Text = "mnemonic for Load accumulator data into output register and its OPCODE is 1110."
            Case 17
                Label2.Text = "at the end of the computer run, the accumulator contains the answer to the problem being solved. At this point, we need to transfer the answer to the outside world. This register holds the output of OUT instruction."
        End Select
    End Sub
End Class