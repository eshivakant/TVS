// Write your Javascript code.


$(document).ready(function () {

    var navListItems = $('div.setup-panel div a'),
            allWells = $('.setup-content'),
            allNextBtn = $('.nextBtn');

    allWells.hide();

    navListItems.click(function (e) {
        e.preventDefault();
        var $target = $($(this).attr('href')),
                $item = $(this);

        if (!$item.hasClass('disabled')) {
            navListItems.removeClass('btn-primary').addClass('btn-default');
            $item.addClass('btn-primary');
            allWells.hide();
            $target.show();
            //$target.find('input:eq(0)').focus();
        }
    });

    allNextBtn.click(function () {
        var curStep = $(this).closest(".setup-content"),
            curStepBtn = curStep.attr("id"),
            nextStepWizard = $('div.setup-panel div a[href="#' + curStepBtn + '"]').parent().next().children("a"),
            curInputs = curStep.find("input[type='text'],input[type='url']"),
            isValid = true;

        $(".form-group").removeClass("has-error");
        for (var i = 0; i < curInputs.length; i++) {
            if (!curInputs[i].validity.valid) {
                isValid = false;
                $(curInputs[i]).closest(".form-group").addClass("has-error");
            }
        }

        if (isValid)
            nextStepWizard.removeAttr('disabled').trigger('click');
    });

    $('div.setup-panel div a.btn-primary').click();

    var primaryButtons = $('.stepwizard-step:nth-child(1) .btn-default');

    var tabs = $('.btn-success');

    if (tabs != undefined && tabs.length > 0)
    tabs[0].onclick = function (e) {
        $('#category').slideUp();

        var tab = $("#tab1");
        if (tab != undefined) {
            tab.fadeIn();
            primaryButtons[0].click();
        }
        //alert('1');
    };

    if (tabs != undefined && tabs.length >1)
    tabs[1].onclick = function (e) {
        $('#category').slideUp();

        var tab = $("#tab2");
        if (tab != undefined) {
            tab.fadeIn();
            primaryButtons[1].click();
        }
        //alert('2');
    };

    if (tabs != undefined && tabs.length >2)
    tabs[2].onclick = function (e) {
        $('#category').slideUp();

        var tab = $("#tab3");
        if (tab != undefined) {
            tab.fadeIn();
            primaryButtons[2].click();
            //alert('3');
        }
    };

    primaryButtons[0].click();
   
});

