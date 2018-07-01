<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormChooseTemplate.aspx.cs" Inherits="IELTS_Listening_Test_System.FormChooseTemplate" MasterPageFile="~/FormMainPage.Master" %>


<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">
           
                <table>
                    <tr>
                        <td class="container">
                            <div class="auto-style30">
                            <asp:ImageButton ID="btnMatching" runat="server" ImageUrl="matching.jpg" cssclass="image"/>
                            </div>
                            <div class="middle">
                                <div class="text">Matching</div>
                            </div>
                        </td>
                        <td class="container">
                            <asp:ImageButton ID="btnMultipleChoice" runat="server" ImageUrl="multiple_choice.jpg" cssclass="image"/>
                            <div class="middle">
                                <div class="text">Multiple Choice</div>
                            </div>
                        </td>
                        <td class="container">
                            <div class="auto-style30">
                            <asp:ImageButton ID="btnNote" runat="server" ImageUrl="note.jpg" cssclass="image"/>
                            </div>
                            <div class="middle">
                                <div class="text">Form, Note, Table</div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style24"></td>
                        <td class="auto-style25"></td>
                        <td class="auto-style22"></td>
                    </tr>
                    <tr>
                        <td class="auto-style24">&nbsp;</td>
                        <td class="auto-style25">&nbsp;</td>
                        <td class="auto-style22">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="container">
                            <div class="auto-style30">
                            <asp:ImageButton ID="btnSentenceComplete" runat="server" ImageUrl="sentence_completion.jpg" CssClass="image"/>
                            </div>
                            <div class="middle">
                                <div class="text">Sentences Completion</div>
                            </div>
                        </td>
                        <td class="container">
                            <div class="auto-style30">
                            <asp:ImageButton ID="btnShortQuestion" runat="server" ImageUrl="short_question.jpg" CssClass="image" />
                            </div>
                            <div class="middle">
                                <div class="text">Short Question</div>
                            </div>
                        </td>
                        <td class="container">
                            <div class="auto-style30">
                            <asp:ImageButton ID="btnGraph" runat="server" ImageUrl="graph.jpg" CssClass="image"/>
                             </div>
                             <div class="middle">
                                <div class="text">Plan, Map, Diagram Labelling</div>
                            </div>
                        </td>
                    </tr>
                </table>
            
        </asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style24 {
            width: 304px;
            height: 25px;
            text-align: center;
        }
        .auto-style25 {
            width: 286px;
            height: 25px;
        }
        
  </style>

    <style type="text/css">
        .auto-style22 {
            height: 25px;
            width: 290px;
        }
    </style>

    <style>
        .container {
            position: relative;
            width: 20%;
        }

        .image {
            opacity: 1;
            display: block;
            width: 70%;
            height: auto;
            transition: .5s ease;
            backface-visibility: hidden;
        }

        .middle {
            transition: .5s ease;
            opacity: 0;
            position: absolute;
            top: 50%;
            left: 35%;
            transform: translate(-50%, -50%);
            -ms-transform: translate(-50%, -50%);
            text-align: center;
        }

        .container:hover .image {
            opacity: 0.3;
        }

        .container:hover .middle {
            opacity: 1;
        }

        .text {
            background-color: #4CAF50;
            color: white;
            font-size: 16px;
            padding: 16px 32px;
        }
        .auto-style30 {
            text-align: center;
        }
    </style> 

</asp:Content>





