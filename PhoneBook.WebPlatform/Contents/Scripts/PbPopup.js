

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
            draggable: false,
            height: "200px",
            width: "400px"
        };
        var opts = $.extend(defaults, options);
        var modalBoxOverlay = $('<div/>').addClass("modalBoxOverlay");
        var modalBox = $('<div/>').addClass("modalBox");
        var modalBoxHeader = $('<div/>').addClass("modalBoxHeader");
        var modalBoxHeaderText = $('<span/>').text(opts.title);
        var modalBoxClose = $('<a/>').attr({ href: "#", title: "Close" }).addClass("modalBoxClose");
        var modalBoxBody = $('<div/>').addClass("modalBoxBody");
        modalBoxBody.css({ height: opts.height });
        modalBox.css({ width: opts.width });
        modalBoxHeaderText.appendTo(modalBoxHeader);
        modalBoxClose.appendTo(modalBoxHeader);
        modalBoxHeader.appendTo(modalBox);
        modalBoxBody.appendTo(modalBox);
        modalBox.appendTo(modalBoxOverlay);
        modalBoxBody.load(opts.url);
        modalBoxOverlay.appendTo('body');

        if (opts.draggable)
            modalBox.draggable({ containment: modalBoxOverlay, handle: modalBoxHeader });
        modalBoxHeader.css({ cursor: "move" });
        $('.modalBoxClose').click(function () {
            $.modalBox.removeModalBox({ obj: modalBoxOverlay });
        });
        $.modalBox.removeModalBox = function (params) {
            params.obj.remove();
        };

        return this;
    };
})(jQuery);