<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MomocloGrid.aspx.cs" Inherits="Momoclo.MomocloGrid" %>

<!DOCTYPE html>

<html lang="ja">
<head runat="server">
    <title>jQuery Demo</title>
    <link rel="stylesheet" href="/CSS/MyStyle.css" type="text/css" />
    <link rel="stylesheet" href="/CSS/smoothness/jquery-ui-1.10.3.custom.min.css" />
    <link rel="stylesheet" href="/CSS/ui.jqgrid.css" />
    <script src="/Scripts/jquery-1.9.0.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.jqGrid.min.js" type="text/javascript"></script>
    <script src="/Scripts/i18n/grid.locale-ja.js" type="text/javascript"></script>
    <%--<script src="/Scripts/i18n/jquery.ui.datepicker-ja.js" type="text/javascript"></script>--%>
    <script src="/Scripts/Momoclo/MomocloGrid.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server" onsubmit="return false;">
    <div>
      <button>SAVE</button>
      <br />
      <table id="momoclo">
      </table>
      <div id="pager"></div>
      <div id="documentDialog" title="Document"></div>
    </div>
    </form>
</body>
</html>
