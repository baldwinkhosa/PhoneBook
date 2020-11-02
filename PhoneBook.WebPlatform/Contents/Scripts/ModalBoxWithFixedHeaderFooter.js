//************************************************************************//
//  <div class='modalBoxOverlay'>                                         //             
//      <div class='modalBox'>                                            //
//          <div class='modalBoxHeader'>                                  //
//              A simple modal box in jQuery                              //
//              <a href="#" class="modalBoxClose" title="Close"></a>      //
//          </div>                                                        //
//          <div class='modalBoxBody'>                                    //
//           Loads Content from specified page.                           //
//          </div>                                                        //
//      </div>                                                            //
//  </div>                                                                //
//************************************************************************//
(function ($) {
    $.modalBox = function (options) {
        var defaults = {
            title: 'MVC Phonebook',
            height: '200px',
            width: '450px',
            draggable: false,
            buttons: {
                'cancel': {
                    action: "cancel",
                    "class": "sBtn",
                    text: "Cancel",
                    id: "btCancel"
                }
            }
        };
        var opts = $.extend(defaults, options);
        var modalBoxOverlay = $('<div/>').addClass("modalBoxOverlay");
        var modalBox = $('<div/>').addClass("modalBox");
        var modalBoxHeader = $('<div/>').addClass("modalBoxHeader");
        var modalBoxHeaderText = $('<span/>').text(opts.title);
        var modalBoxClose = $('<a/>').attr({ href: "#", title: "Close" }).addClass("modalBoxClose");
        var modalBoxBody = $('<div/>').addClass("modalBoxBody").load(opts.url);
        $(document).ajaxStart(function () {
            alert('ajax start');
        }).ajaxComplete(function () {
            alert('ajax complete');
        });
        var modalBoxFooter = $('<div/>').addClass("modalBoxFooter");
        var modalButton;
        var i = 0;
        $.each(opts.buttons, function (name, obj) {
            modalButton = $('<button/>').attr({ type: obj.action, id: ++i, 'class': obj.class }).text(name);
            modalButton.appendTo(modalBoxFooter);
        });
        modalBoxHeaderText.appendTo(modalBoxHeader);
        modalBoxClose.appendTo(modalBoxHeader);
        modalBoxHeader.appendTo(modalBox);
        modalBoxBody.appendTo(modalBox);
        modalBoxFooter.appendTo(modalBox);

        modalBox.appendTo(modalBoxOverlay);
        //css 
        modalBoxOverlay.css({
            width: "100%",
            height: "100%",
            position: "fixed",
            top: 0,
            left: 0,
            zIndex: 10,
            background: "none repeat scroll 0 0 rgba(0, 0, 0, 0.5)",
        });
        modalBox.css({
            backgroundColor: "#ffffff",
            position: "relative",
            width: opts.width,
            margin: "10% auto",
            zIndex: "11",
        });
        modalBoxBody.css({
            height: opts.height,
            overflowX: "hidden",
            overflowY: "auto",
        });
        modalBoxClose.css({
            background: "url('../Contents/Images/close.png') no-repeat",
            float: "right",
            width: "16px",
            height: "16px",
        });
        modalBoxHeader.css({
            padding: "10px 5px",
            backgroundColor: "#f5f5f5",
            borderBottom: "1px solid #dddddd"
        });
        modalBoxHeaderText.css({
            paddingLeft: "5px"
        });
        //style end

        modalBoxOverlay.fadeIn(700).appendTo('body');
        $('body').css({ overflow: "hidden" });
        if (opts.draggable)
            modalBox.draggable({ containment: modalBoxOverlay, cursor: "move" });
        $('.modalBoxClose').click(function () {
            removeModalBox();
        });
        $.each(opts.buttons, function (name, obj) {
            $("#" + obj.id + "").click(function () {
                switch (obj.action) {
                    case "submit":
                        $('.modalBoxBody form').submit();
                        break;
                    case "cancel":
                        removeModalBox();
                        break;
                }
            });
        });
        function removeModalBox() {
            modalBox.slideUp('fast', function () {
                modalBoxOverlay.fadeOut(700, function () {
                    this.remove();
                });
                $('body').css({ overflow: "auto" });
            });
        };
        return this;
    };
})(jQuery);