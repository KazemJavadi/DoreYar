var input_card_answer_element = document.getElementById('Input_Card_Answer');
if (input_card_answer_element != null) input_card_answer_element.hidden = true;

import BalloonEditor from '@ckeditor/ckeditor5-editor-balloon/src/ballooneditor';
import EssentialsPlugin from '@ckeditor/ckeditor5-essentials/src/essentials';
import UploadAdapterPlugin from '@ckeditor/ckeditor5-adapter-ckfinder/src/uploadadapter';
import AutoformatPlugin from '@ckeditor/ckeditor5-autoformat/src/autoformat';
import BoldPlugin from '@ckeditor/ckeditor5-basic-styles/src/bold';
import ItalicPlugin from '@ckeditor/ckeditor5-basic-styles/src/italic';
import BlockQuotePlugin from '@ckeditor/ckeditor5-block-quote/src/blockquote';
import HeadingPlugin from '@ckeditor/ckeditor5-heading/src/heading';
import ParagraphPlugin from '@ckeditor/ckeditor5-paragraph/src/paragraph';
import Alignment from '@ckeditor/ckeditor5-alignment/src/alignment';
import List from '@ckeditor/ckeditor5-list/src/list';
//import HorizontalLine from '@ckeditor/ckeditor5-horizontal-line/src/horizontalline';
import Highlight from '@ckeditor/ckeditor5-highlight/src/highlight';

import Bold from '@ckeditor/ckeditor5-basic-styles/src/bold';
import Italic from '@ckeditor/ckeditor5-basic-styles/src/italic';
import Underline from '@ckeditor/ckeditor5-basic-styles/src/underline';
import Strikethrough from '@ckeditor/ckeditor5-basic-styles/src/strikethrough';
import Code from '@ckeditor/ckeditor5-basic-styles/src/code';
import Subscript from '@ckeditor/ckeditor5-basic-styles/src/subscript';
import Superscript from '@ckeditor/ckeditor5-basic-styles/src/superscript';

import CodeBlock from '@ckeditor/ckeditor5-code-block/src/codeblock';
import Clipboard from '@ckeditor/ckeditor5-clipboard/src/clipboard';
import PasteFromOffice from '@ckeditor/ckeditor5-paste-from-office/src/pastefromoffice';

import Indent from '@ckeditor/ckeditor5-indent/src/indent';
import IndentBlock from '@ckeditor/ckeditor5-indent/src/indentblock';


BalloonEditor
    .create(document.querySelector('#editor'), {
        placeholder: 'پاسخ را اینجا بنویسید ...',
        // The plugins are now passed directly to .create().
        plugins: [
            EssentialsPlugin,
            AutoformatPlugin,
            BoldPlugin,
            ItalicPlugin,
            BlockQuotePlugin,
            HeadingPlugin,
            ParagraphPlugin,
            UploadAdapterPlugin,
            Alignment,
            List,
            //HorizontalLine,
            Highlight,
            Bold, Italic, Underline, Strikethrough, Code, Subscript, Superscript,
            CodeBlock,
            Clipboard,
            PasteFromOffice,
            Indent, IndentBlock
        ],

        // So is the rest of the default configuration.
        toolbar: [
            'textPartLanguage',
            'heading',
            'bold',
            'italic',
            'underline', 'strikethrough', 'code', 'subscript', 'superscript',
            'bulletedList',
            'numberedList',
            'blockQuote',
            'undo',
            'redo',
            `alignment`,
            'outdent', 'indent',
            //'horizontalLine',
            '|',
            'highlight:yellowMarker', 'highlight:greenMarker', 'highlight:pinkMarker',
            'highlight:greenPen', 'highlight:redPen', 'removeHighlight',
            '|',
            'codeBlock'
        ],
        image: {
            toolbar: [
                'imageStyle:inline',
                'imageStyle:block',
                'imageStyle:side',
                '|',
                'toggleImageCaption',
                'imageTextAlternative'
            ]
        },
        codeBlock: {
            languages: [
                { language: 'plaintext', label: 'Plain text' }, // The default language.
                { language: 'c', label: 'C' },
                { language: 'cs', label: 'C#' },
                { language: 'cpp', label: 'C++' },
                { language: 'css', label: 'CSS' },
                { language: 'diff', label: 'Diff' },
                { language: 'html', label: 'HTML' },
                { language: 'java', label: 'Java' },
                { language: 'javascript', label: 'JavaScript' },
                { language: 'php', label: 'PHP' },
                { language: 'python', label: 'Python' },
                { language: 'ruby', label: 'Ruby' },
                { language: 'typescript', label: 'TypeScript' },
                { language: 'xml', label: 'XML' }
            ]
        },
        highlight: {
            options: [
                { model: 'yellowMarker', class: 'marker-yellow', title: 'Yellow Marker', color: 'var(--ck-highlight-marker-yellow)', type: 'marker' },
                { model: 'greenMarker', class: 'marker-green', title: 'Green marker', color: 'var(--ck-highlight-marker-green)', type: 'marker' },
                { model: 'pinkMarker', class: 'marker-pink', title: 'Pink marker', color: 'var(--ck-highlight-marker-pink)', type: 'marker' },
                { model: 'blueMarker', class: 'marker-blue', title: 'Blue marker', color: 'var(--ck-highlight-marker-blue)', type: 'marker' },
                { model: 'redPen', class: 'pen-red', title: 'Red pen', color: 'var(--ck-highlight-pen-red)', type: 'pen' },
                { model: 'greenPen', class: 'pen-green', title: 'Green pen', color: 'var(--ck-highlight-pen-green)', type: 'pen' }
            ]
        },
        language: {
            // The UI will be English.
            ui: 'fa',

            // But the content will be edited in Arabic.
            content: 'fa',
        }
    })
    .then(editor => {
        console.log(editor);
    })
    .catch(error => {
        console.error(error);
    });

//.create(document.querySelector('#editor'), {
//    plugins: [Alignment],     // <--- MODIFIED
//})
//.then(editor => {
//    console.log('Editor was initialized', editor);
//})
//.catch(error => {
//    console.error(error.stack);
//});

var submitButton = document.querySelector('#submit');
if (submitButton != null) {
    document.querySelector('#submit').addEventListener('click', () => {
        var innerHtml = document.getElementById('editor').innerHTML;
        if (innerHtml.includes('<br data-cke-filler="true">')) {
            document.getElementById('Input_Card_Answer').value = null;
        }
        else {
            document.getElementById('Input_Card_Answer').value = innerHtml;
        }
    }
    );
}