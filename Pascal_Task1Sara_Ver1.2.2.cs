
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF                =   0, // (EOF)
        SYMBOL_ERROR              =   1, // (Error)
        SYMBOL_WHITESPACE         =   2, // Whitespace
        SYMBOL_MINUS              =   3, // '-'
        SYMBOL_AMP                =   4, // '&'
        SYMBOL_LPAREN             =   5, // '('
        SYMBOL_RPAREN             =   6, // ')'
        SYMBOL_TIMES              =   7, // '*'
        SYMBOL_COMMA              =   8, // ','
        SYMBOL_DIV                =   9, // '/'
        SYMBOL_COLON              =  10, // ':'
        SYMBOL_COLONEQ            =  11, // ':='
        SYMBOL_SEMI               =  12, // ';'
        SYMBOL_LBRACE             =  13, // '{'
        SYMBOL_PIPE               =  14, // '|'
        SYMBOL_RBRACE             =  15, // '}'
        SYMBOL_PLUS               =  16, // '+'
        SYMBOL_LT                 =  17, // '<'
        SYMBOL_LTEQ               =  18, // '<='
        SYMBOL_LTGT               =  19, // '<>'
        SYMBOL_EQ                 =  20, // '='
        SYMBOL_GT                 =  21, // '>'
        SYMBOL_GTEQ               =  22, // '>='
        SYMBOL_AND                =  23, // and
        SYMBOL_BEGIN              =  24, // begin
        SYMBOL_BOOLEAN            =  25, // boolean
        SYMBOL_BREAK              =  26, // Break
        SYMBOL_CHAR               =  27, // Char
        SYMBOL_CHARACTER          =  28, // character
        SYMBOL_CONST              =  29, // const
        SYMBOL_CONTINUE           =  30, // Continue
        SYMBOL_CURLYBRACET        =  31, // CurlyBracet
        SYMBOL_DO                 =  32, // DO
        SYMBOL_DOWNTO             =  33, // 'Down To'
        SYMBOL_ELSE               =  34, // else
        SYMBOL_END                =  35, // END
        SYMBOL_ENDDOT             =  36, // 'end.'
        SYMBOL_FALSE              =  37, // false
        SYMBOL_FLOAT              =  38, // Float
        SYMBOL_FOR                =  39, // For
        SYMBOL_FUNCTION           =  40, // function
        SYMBOL_GOTO               =  41, // GoTo
        SYMBOL_IDENTIFIER         =  42, // Identifier
        SYMBOL_IF                 =  43, // if
        SYMBOL_INT                =  44, // int
        SYMBOL_INTEGER            =  45, // Integer
        SYMBOL_LABEL              =  46, // Label
        SYMBOL_NEWLINE            =  47, // NewLine
        SYMBOL_NOT                =  48, // Not
        SYMBOL_OR                 =  49, // or
        SYMBOL_PROCEDURE          =  50, // Procedure
        SYMBOL_PROGRAM            =  51, // 'program '
        SYMBOL_READ               =  52, // read
        SYMBOL_READLN             =  53, // readln
        SYMBOL_REAL               =  54, // Real
        SYMBOL_REPEAT             =  55, // Repeat
        SYMBOL_SINGLEQOUT         =  56, // Singleqout
        SYMBOL_STRING             =  57, // String
        SYMBOL_THEN               =  58, // THEN
        SYMBOL_TO                 =  59, // TO
        SYMBOL_TRUE               =  60, // true
        SYMBOL_UNTILL             =  61, // Untill
        SYMBOL_USES               =  62, // uses
        SYMBOL_VAR                =  63, // var
        SYMBOL_WHILE              =  64, // While
        SYMBOL_WRITE              =  65, // write
        SYMBOL_WRITELN            =  66, // writeln
        SYMBOL_ADDEXP             =  67, // <Add Exp>
        SYMBOL_ADDOP              =  68, // <Addop>
        SYMBOL_AND2               =  69, // <And>
        SYMBOL_ARG_NAME           =  70, // <Arg_name>
        SYMBOL_ARGUMENT_SEC       =  71, // <Argument_Sec>
        SYMBOL_ASSIGNMENT_STMT    =  72, // <Assignment_Stmt>
        SYMBOL_BEGIN2             =  73, // <Begin>
        SYMBOL_BOOLEAN_EXPRESSION =  74, // <Boolean_Expression>
        SYMBOL_BR                 =  75, // <Br>
        SYMBOL_BREAK2             =  76, // <Break>
        SYMBOL_CALL_FUN           =  77, // <Call_Fun>
        SYMBOL_COMMENT            =  78, // <Comment>
        SYMBOL_COMMENT_STRING     =  79, // <Comment_String>
        SYMBOL_CON                =  80, // <Con>
        SYMBOL_CONDITION          =  81, // <Condition>
        SYMBOL_CONST2             =  82, // <Const>
        SYMBOL_CONST_VAR          =  83, // <Const_Var>
        SYMBOL_CONSTANT           =  84, // <Constant>
        SYMBOL_CONSTANT_VALUE     =  85, // <constant_value>
        SYMBOL_CONTINUE2          =  86, // <Continue>
        SYMBOL_DO2                =  87, // <Do>
        SYMBOL_ELSE2              =  88, // <Else>
        SYMBOL_END2               =  89, // <End>
        SYMBOL_END_MAIN           =  90, // <End_Main>
        SYMBOL_EXP                =  91, // <Exp>
        SYMBOL_EXPRESSION         =  92, // <Expression>
        SYMBOL_FACTOR             =  93, // <Factor>
        SYMBOL_FOR2               =  94, // <For>
        SYMBOL_FOR_STMT           =  95, // <For_Stmt>
        SYMBOL_FUN                =  96, // <Fun>
        SYMBOL_FUN_DECLARATION    =  97, // <Fun_Declaration>
        SYMBOL_FUN_NAME           =  98, // <Fun_Name>
        SYMBOL_FUN_SEC            =  99, // <Fun_Sec>
        SYMBOL_FUNCTION2          = 100, // <Function>
        SYMBOL_FUNCTION_CONTENT   = 101, // <Function_Content>
        SYMBOL_GO                 = 102, // <Go>
        SYMBOL_GO_TO              = 103, // <Go_To>
        SYMBOL_IF2                = 104, // <If>
        SYMBOL_IF_STATMENT        = 105, // <IF_Statment>
        SYMBOL_LABEL_GO           = 106, // <Label_go>
        SYMBOL_LABEL_STMT         = 107, // <Label_Stmt>
        SYMBOL_MAIN_BLOCK         = 108, // <Main_Block>
        SYMBOL_MULOP              = 109, // <Mulop>
        SYMBOL_MULTEXP            = 110, // <MultExp>
        SYMBOL_NEGATEEXP          = 111, // <Negate Exp>
        SYMBOL_NL                 = 112, // <nl>
        SYMBOL_NLOPT              = 113, // <nl Opt>
        SYMBOL_NOT2               = 114, // <Not>
        SYMBOL_ONELINE            = 115, // <OneLine>
        SYMBOL_OP                 = 116, // <OP>
        SYMBOL_OR2                = 117, // <Or>
        SYMBOL_PRO                = 118, // <Pro>
        SYMBOL_PROC               = 119, // <Proc>
        SYMBOL_PROC_ARGDEC        = 120, // <Proc_ArgDec>
        SYMBOL_PROC_CONTENT       = 121, // <Proc_Content>
        SYMBOL_PROC_SEC           = 122, // <Proc_Sec>
        SYMBOL_PROCEDURE2         = 123, // <Procedure>
        SYMBOL_PROGRAM2           = 124, // <Program>
        SYMBOL_PROGRAM_NAME       = 125, // <Program_Name>
        SYMBOL_PROGRAM_SEC        = 126, // <Program_Sec>
        SYMBOL_READ2              = 127, // <Read>
        SYMBOL_READ_LINE          = 128, // <Read_Line>
        SYMBOL_REP                = 129, // <Rep>
        SYMBOL_REPEAT_STMT        = 130, // <Repeat_Stmt>
        SYMBOL_SEND_TO            = 131, // <Send_To>
        SYMBOL_STMT               = 132, // <Stmt>
        SYMBOL_STMT_SEQUENCE      = 133, // <Stmt_sequence>
        SYMBOL_SYNTAXREAD         = 134, // <syntaxread>
        SYMBOL_SYNTAXWRITE        = 135, // <syntaxwrite>
        SYMBOL_TERM               = 136, // <Term>
        SYMBOL_TF                 = 137, // <TF>
        SYMBOL_THEN2              = 138, // <Then>
        SYMBOL_TO2                = 139, // <To>
        SYMBOL_TYPE               = 140, // <type>
        SYMBOL_UNTILL2            = 141, // <Untill>
        SYMBOL_USES2              = 142, // <Uses>
        SYMBOL_USES_COMMAND       = 143, // <Uses_Command>
        SYMBOL_VALUE              = 144, // <Value>
        SYMBOL_VALUES             = 145, // <Values>
        SYMBOL_VAR_DEC            = 146, // <Var_Dec>
        SYMBOL_VAR_NAMES          = 147, // <Var_Names>
        SYMBOL_VAR_WORD           = 148, // <Var_Word>
        SYMBOL_VARIABLE_SEC       = 149, // <Variable_Sec>
        SYMBOL_WHILE2             = 150, // <While>
        SYMBOL_WHILE_STMT         = 151, // <While_stmt>
        SYMBOL_WORDREAD           = 152, // <WordRead>
        SYMBOL_WORDREADLINE       = 153, // <WordReadLine>
        SYMBOL_WORDWRITE          = 154, // <WordWrite>
        SYMBOL_WORDWRITELINE      = 155, // <WordWriteLine>
        SYMBOL_WRITE2             = 156, // <Write>
        SYMBOL_WRITE_LINE         = 157  // <Write_Line>
    };

    enum RuleConstants : int
    {
        RULE_NL_NEWLINE                                                                               =   0, // <nl> ::= NewLine <nl>
        RULE_NL_NEWLINE2                                                                              =   1, // <nl> ::= NewLine
        RULE_NLOPT_NEWLINE                                                                            =   2, // <nl Opt> ::= NewLine <nl Opt>
        RULE_NLOPT                                                                                    =   3, // <nl Opt> ::= 
        RULE_PRO                                                                                      =   4, // <Pro> ::= <Program_Name>
        RULE_PROGRAM_NAME_SEMI_NEWLINE                                                                =   5, // <Program_Name> ::= <Comment> <Program_Sec> ';' NewLine <Uses_Command>
        RULE_PROGRAM_NAME_SEMI_NEWLINE_NEWLINE                                                        =   6, // <Program_Name> ::= <Program_Sec> ';' NewLine <Comment> NewLine <Uses_Command>
        RULE_PROGRAM_NAME_SEMI_NEWLINE2                                                               =   7, // <Program_Name> ::= <Program_Sec> ';' NewLine <Uses_Command>
        RULE_PROGRAM_SEC_IDENTIFIER                                                                   =   8, // <Program_Sec> ::= <Program> Identifier
        RULE_PROGRAM_PROGRAM                                                                          =   9, // <Program> ::= 'program '
        RULE_COMMENT_LBRACE_TIMES_TIMES_RBRACE                                                        =  10, // <Comment> ::= '{' '*' <Comment_String> '*' '}'
        RULE_COMMENT_LBRACE_RBRACE                                                                    =  11, // <Comment> ::= '{' <OneLine> '}'
        RULE_COMMENT_STRING_STRING                                                                    =  12, // <Comment_String> ::= String <nl Opt> <Comment_String>
        RULE_COMMENT_STRING                                                                           =  13, // <Comment_String> ::= <nl Opt>
        RULE_ONELINE_STRING                                                                           =  14, // <OneLine> ::= String
        RULE_USES_COMMAND_NEWLINE_IDENTIFIER_SEMI                                                     =  15, // <Uses_Command> ::= <Uses> NewLine Identifier ';' <Comment> <Uses_Command> <Const>
        RULE_USES_COMMAND_NEWLINE_IDENTIFIER_SEMI2                                                    =  16, // <Uses_Command> ::= <Uses> NewLine Identifier ';' <Uses_Command> <Const>
        RULE_USES_COMMAND                                                                             =  17, // <Uses_Command> ::= <Const>
        RULE_USES_COMMAND_IDENTIFIER_NEWLINE                                                          =  18, // <Uses_Command> ::= <Uses> Identifier NewLine <Const>
        RULE_USES_USES                                                                                =  19, // <Uses> ::= uses
        RULE_CONST_NEWLINE_NEWLINE                                                                    =  20, // <Const> ::= <Constant> <Const_Var> NewLine <Comment> NewLine <Variable_Sec>
        RULE_CONST                                                                                    =  21, // <Const> ::= <Variable_Sec>
        RULE_CONST_NEWLINE                                                                            =  22, // <Const> ::= <Constant> <Const_Var> NewLine <Variable_Sec>
        RULE_CONSTANT_CONST                                                                           =  23, // <Constant> ::= const
        RULE_CONSTANT_VALUE_STRING                                                                    =  24, // <constant_value> ::= String
        RULE_CONSTANT_VALUE_REAL                                                                      =  25, // <constant_value> ::= Real
        RULE_CONSTANT_VALUE_INTEGER                                                                   =  26, // <constant_value> ::= Integer
        RULE_CONSTANT_VALUE_CHAR                                                                      =  27, // <constant_value> ::= Char
        RULE_CONSTANT_VALUE                                                                           =  28, // <constant_value> ::= <TF>
        RULE_TF_TRUE                                                                                  =  29, // <TF> ::= true
        RULE_TF_FALSE                                                                                 =  30, // <TF> ::= false
        RULE_CONST_VAR_COLON_SEMI                                                                     =  31, // <Const_Var> ::= <Arg_name> ':' <constant_value> ';' <Const_Var>
        RULE_CONST_VAR_COLON_SEMI2                                                                    =  32, // <Const_Var> ::= <Arg_name> ':' <constant_value> ';'
        RULE_ARG_NAME_IDENTIFIER                                                                      =  33, // <Arg_name> ::= Identifier
        RULE_TYPE_BOOLEAN                                                                             =  34, // <type> ::= boolean
        RULE_TYPE_CHARACTER                                                                           =  35, // <type> ::= character
        RULE_TYPE_INT                                                                                 =  36, // <type> ::= int
        RULE_TYPE                                                                                     =  37, // <type> ::= 
        RULE_VARIABLE_SEC_NEWLINE                                                                     =  38, // <Variable_Sec> ::= <Var_Word> NewLine <Var_Dec>
        RULE_VARIABLE_SEC_IDENTIFIER_NEWLINE                                                          =  39, // <Variable_Sec> ::= <Proc> Identifier NewLine
        RULE_VARIABLE_SEC_NEWLINE2                                                                    =  40, // <Variable_Sec> ::= <Fun_Declaration> NewLine
        RULE_VAR_DEC_COLON_SEMI_NEWLINE                                                               =  41, // <Var_Dec> ::= <Var_Names> ':' <type> ';' NewLine <Var_Dec>
        RULE_VAR_DEC_NEWLINE                                                                          =  42, // <Var_Dec> ::= <Assignment_Stmt> NewLine <Var_Dec>
        RULE_VAR_DEC                                                                                  =  43, // <Var_Dec> ::= 
        RULE_VAR_WORD_VAR                                                                             =  44, // <Var_Word> ::= var
        RULE_VAR_NAMES_COMMA                                                                          =  45, // <Var_Names> ::= <Var_Names> ',' <Arg_name>
        RULE_VAR_NAMES                                                                                =  46, // <Var_Names> ::= <Arg_name>
        RULE_FUNCTION                                                                                 =  47, // <Function> ::= <Fun_Sec>
        RULE_FUNCTION_NEWLINE_NEWLINE_NEWLINE                                                         =  48, // <Function> ::= <Fun_Sec> NewLine <Comment> NewLine <Procedure> NewLine
        RULE_FUNCTION_NEWLINE_NEWLINE_NEWLINE_NEWLINE                                                 =  49, // <Function> ::= <Fun_Sec> NewLine <Comment> NewLine <Procedure> NewLine <Comment> NewLine
        RULE_FUNCTION_NEWLINE_NEWLINE_NEWLINE2                                                        =  50, // <Function> ::= <Fun_Sec> NewLine <Procedure> NewLine <Comment> NewLine
        RULE_FUNCTION_NEWLINE_NEWLINE                                                                 =  51, // <Function> ::= <Fun_Sec> NewLine <Procedure> NewLine
        RULE_FUN_SEC_NEWLINE_NEWLINE                                                                  =  52, // <Fun_Sec> ::= <Fun_Declaration> NewLine <Variable_Sec> NewLine <Function_Content> <Fun_Sec>
        RULE_FUN_SEC_NEWLINE_SEMI                                                                     =  53, // <Fun_Sec> ::= <Fun_Declaration> NewLine <Variable_Sec> ';' <Function_Content>
        RULE_FUN_DECLARATION_LPAREN_RPAREN_COLON_SEMI                                                 =  54, // <Fun_Declaration> ::= <Fun> <Fun_Name> '(' <Argument_Sec> ')' ':' <type> ';'
        RULE_FUN_FUNCTION                                                                             =  55, // <Fun> ::= function
        RULE_FUN_NAME_IDENTIFIER                                                                      =  56, // <Fun_Name> ::= Identifier
        RULE_ARGUMENT_SEC_COLON_SEMI                                                                  =  57, // <Argument_Sec> ::= <Arg_name> ':' <type> ';' <Argument_Sec>
        RULE_ARGUMENT_SEC                                                                             =  58, // <Argument_Sec> ::= 
        RULE_FUNCTION_CONTENT_NEWLINE_NEWLINE_NEWLINE_NEWLINE_NEWLINE_COLONEQ_NEWLINE_NEWLINE_SEMI    =  59, // <Function_Content> ::= <Stmt_sequence> NewLine <Begin> NewLine <Comment> NewLine <Stmt_sequence> NewLine <Comment> NewLine <Fun_Name> ':=' <Arg_name> NewLine <Comment> NewLine <End> ';'
        RULE_FUNCTION_CONTENT_NEWLINE_NEWLINE_NEWLINE_NEWLINE_COLONEQ_NEWLINE_NEWLINE_SEMI            =  60, // <Function_Content> ::= <Stmt_sequence> NewLine <Begin> NewLine <Stmt_sequence> NewLine <Comment> NewLine <Fun_Name> ':=' <Arg_name> NewLine <Comment> NewLine <End> ';'
        RULE_FUNCTION_CONTENT_NEWLINE_NEWLINE_NEWLINE_NEWLINE_COLONEQ_NEWLINE_NEWLINE_SEMI2           =  61, // <Function_Content> ::= <Stmt_sequence> NewLine <Begin> NewLine <Comment> NewLine <Stmt_sequence> NewLine <Fun_Name> ':=' <Arg_name> NewLine <Comment> NewLine <End> ';'
        RULE_FUNCTION_CONTENT_NEWLINE_NEWLINE_NEWLINE_NEWLINE_NEWLINE_COLONEQ_NEWLINE_SEMI            =  62, // <Function_Content> ::= <Stmt_sequence> NewLine <Begin> NewLine <Comment> NewLine <Stmt_sequence> NewLine <Comment> NewLine <Fun_Name> ':=' <Arg_name> NewLine <End> ';'
        RULE_FUNCTION_CONTENT_NEWLINE_NEWLINE_NEWLINE_COLONEQ_NEWLINE_NEWLINE_SEMI                    =  63, // <Function_Content> ::= <Stmt_sequence> NewLine <Begin> NewLine <Stmt_sequence> NewLine <Fun_Name> ':=' <Arg_name> NewLine <Comment> NewLine <End> ';'
        RULE_FUNCTION_CONTENT_NEWLINE_NEWLINE_NEWLINE_COLONEQ_NEWLINE_SEMI                            =  64, // <Function_Content> ::= <Stmt_sequence> NewLine <Begin> NewLine <Stmt_sequence> NewLine <Fun_Name> ':=' <Arg_name> NewLine <End> ';'
        RULE_FUNCTION_CONTENT_NEWLINE_NEWLINE_NEWLINE_NEWLINE_COLONEQ_NEWLINE_SEMI                    =  65, // <Function_Content> ::= <Stmt_sequence> NewLine <Begin> NewLine <Comment> NewLine <Stmt_sequence> NewLine <Fun_Name> ':=' <Arg_name> NewLine <End> ';'
        RULE_STMT_SEQUENCE                                                                            =  66, // <Stmt_sequence> ::= <Stmt>
        RULE_STMT_SEQUENCE_NEWLINE_NEWLINE_NEWLINE                                                    =  67, // <Stmt_sequence> ::= <Stmt> NewLine <Comment> NewLine <Stmt_sequence> NewLine
        RULE_STMT_SEQUENCE_NEWLINE_NEWLINE                                                            =  68, // <Stmt_sequence> ::= <Stmt> NewLine <Stmt_sequence> NewLine
        RULE_STMT                                                                                     =  69, // <Stmt> ::= <Exp>
        RULE_STMT2                                                                                    =  70, // <Stmt> ::= <Assignment_Stmt>
        RULE_STMT3                                                                                    =  71, // <Stmt> ::= <IF_Statment>
        RULE_STMT4                                                                                    =  72, // <Stmt> ::= <For_Stmt>
        RULE_STMT5                                                                                    =  73, // <Stmt> ::= <Repeat_Stmt>
        RULE_STMT6                                                                                    =  74, // <Stmt> ::= <While_stmt>
        RULE_STMT7                                                                                    =  75, // <Stmt> ::= <Break>
        RULE_STMT8                                                                                    =  76, // <Stmt> ::= <Continue>
        RULE_STMT9                                                                                    =  77, // <Stmt> ::= <Go_To>
        RULE_STMT10                                                                                   =  78, // <Stmt> ::= <Send_To>
        RULE_STMT11                                                                                   =  79, // <Stmt> ::= <Read_Line>
        RULE_STMT12                                                                                   =  80, // <Stmt> ::= <Write_Line>
        RULE_STMT13                                                                                   =  81, // <Stmt> ::= <Read>
        RULE_STMT14                                                                                   =  82, // <Stmt> ::= <Write>
        RULE_STMT15                                                                                   =  83, // <Stmt> ::= <Call_Fun>
        RULE_STMT_NEWLINE                                                                             =  84, // <Stmt> ::= NewLine
        RULE_BREAK_SEMI                                                                               =  85, // <Break> ::= <Br> ';'
        RULE_BR_BREAK                                                                                 =  86, // <Br> ::= Break
        RULE_CONTINUE_SEMI                                                                            =  87, // <Continue> ::= <Con> ';'
        RULE_CON_CONTINUE                                                                             =  88, // <Con> ::= Continue
        RULE_GO_TO_SEMI                                                                               =  89, // <Go_To> ::= <Go> <Send_To> ';'
        RULE_GO_GOTO                                                                                  =  90, // <Go> ::= GoTo
        RULE_SEND_TO_COLON                                                                            =  91, // <Send_To> ::= <Label_go> ':' <Label_Stmt>
        RULE_LABEL_GO_LABEL                                                                           =  92, // <Label_go> ::= Label
        RULE_LABEL_STMT_IDENTIFIER                                                                    =  93, // <Label_Stmt> ::= Identifier
        RULE_LABEL_STMT_CHAR                                                                          =  94, // <Label_Stmt> ::= Char
        RULE_LABEL_STMT_REAL                                                                          =  95, // <Label_Stmt> ::= Real
        RULE_LABEL_STMT_INTEGER                                                                       =  96, // <Label_Stmt> ::= Integer
        RULE_REP_REPEAT                                                                               =  97, // <Rep> ::= Repeat
        RULE_UNTILL_UNTILL                                                                            =  98, // <Untill> ::= Untill
        RULE_REPEAT_STMT_NEWLINE_NEWLINE_NEWLINE_SEMI                                                 =  99, // <Repeat_Stmt> ::= <Rep> NewLine <Comment> NewLine <Stmt_sequence> NewLine <Untill> <Condition> ';'
        RULE_REPEAT_STMT_NEWLINE_NEWLINE_NEWLINE_SEMI2                                                = 100, // <Repeat_Stmt> ::= <Rep> NewLine <Stmt_sequence> NewLine <Comment> NewLine <Untill> <Condition> ';'
        RULE_REPEAT_STMT_NEWLINE_NEWLINE_SEMI                                                         = 101, // <Repeat_Stmt> ::= <Rep> NewLine <Stmt_sequence> NewLine <Untill> <Condition> ';'
        RULE_CONDITION                                                                                = 102, // <Condition> ::= <Expression>
        RULE_CONDITION2                                                                               = 103, // <Condition> ::= <Expression> <OP> <Condition>
        RULE_EXPRESSION_GT                                                                            = 104, // <Expression> ::= <Expression> '>' <Add Exp>
        RULE_EXPRESSION_LT                                                                            = 105, // <Expression> ::= <Expression> '<' <Add Exp>
        RULE_EXPRESSION_LTEQ                                                                          = 106, // <Expression> ::= <Expression> '<=' <Add Exp>
        RULE_EXPRESSION_GTEQ                                                                          = 107, // <Expression> ::= <Expression> '>=' <Add Exp>
        RULE_EXPRESSION_EQ                                                                            = 108, // <Expression> ::= <Expression> '=' <Add Exp>
        RULE_EXPRESSION_LTGT                                                                          = 109, // <Expression> ::= <Expression> '<>' <Add Exp>
        RULE_EXPRESSION                                                                               = 110, // <Expression> ::= <Add Exp>
        RULE_EXPRESSION2                                                                              = 111, // <Expression> ::= <TF>
        RULE_OP_AMP                                                                                   = 112, // <OP> ::= '&'
        RULE_OP_PIPE                                                                                  = 113, // <OP> ::= '|'
        RULE_ADDEXP_PLUS                                                                              = 114, // <Add Exp> ::= <Add Exp> '+' <MultExp>
        RULE_ADDEXP_MINUS                                                                             = 115, // <Add Exp> ::= <Add Exp> '-' <MultExp>
        RULE_ADDEXP                                                                                   = 116, // <Add Exp> ::= <MultExp>
        RULE_MULTEXP_TIMES                                                                            = 117, // <MultExp> ::= <MultExp> '*' <Negate Exp>
        RULE_MULTEXP_DIV                                                                              = 118, // <MultExp> ::= <MultExp> '/' <Negate Exp>
        RULE_MULTEXP                                                                                  = 119, // <MultExp> ::= <Negate Exp>
        RULE_NEGATEEXP_MINUS                                                                          = 120, // <Negate Exp> ::= '-' <Value>
        RULE_NEGATEEXP                                                                                = 121, // <Negate Exp> ::= <Value>
        RULE_VALUE_IDENTIFIER                                                                         = 122, // <Value> ::= Identifier
        RULE_VALUE_FLOAT                                                                              = 123, // <Value> ::= Float
        RULE_VALUE_INTEGER                                                                            = 124, // <Value> ::= Integer
        RULE_VALUE_LPAREN_RPAREN                                                                      = 125, // <Value> ::= '(' <Add Exp> ')'
        RULE_FOR_STMT_IDENTIFIER_COLONEQ_INTEGER_INTEGER_NEWLINE_NEWLINE_NEWLINE_NEWLINE_NEWLINE_SEMI = 126, // <For_Stmt> ::= <For> Identifier ':=' Integer <To> Integer <Do> NewLine <Comment> NewLine <Begin> NewLine <Comment> NewLine <Stmt_sequence> NewLine <Comment> <End> ';'
        RULE_FOR_STMT_IDENTIFIER_COLONEQ_INTEGER_INTEGER_NEWLINE_NEWLINE_NEWLINE_NEWLINE_SEMI         = 127, // <For_Stmt> ::= <For> Identifier ':=' Integer <To> Integer <Do> NewLine <Begin> NewLine <Comment> NewLine <Stmt_sequence> NewLine <Comment> <End> ';'
        RULE_FOR_STMT_IDENTIFIER_COLONEQ_INTEGER_INTEGER_NEWLINE_NEWLINE_NEWLINE_SEMI                 = 128, // <For_Stmt> ::= <For> Identifier ':=' Integer <To> Integer <Do> NewLine <Begin> NewLine <Stmt_sequence> NewLine <Comment> <End> ';'
        RULE_FOR_STMT_IDENTIFIER_COLONEQ_INTEGER_INTEGER_NEWLINE_NEWLINE_NEWLINE_NEWLINE_SEMI2        = 129, // <For_Stmt> ::= <For> Identifier ':=' Integer <To> Integer <Do> NewLine <Comment> NewLine <Begin> NewLine <Stmt_sequence> NewLine <Comment> <End> ';'
        RULE_FOR_STMT_IDENTIFIER_COLONEQ_INTEGER_INTEGER_NEWLINE_NEWLINE_NEWLINE_SEMI2                = 130, // <For_Stmt> ::= <For> Identifier ':=' Integer <To> Integer <Do> NewLine <Comment> NewLine <Begin> NewLine <Stmt_sequence> <End> ';'
        RULE_FOR_STMT_IDENTIFIER_COLONEQ_INTEGER_INTEGER_NEWLINE_NEWLINE_NEWLINE_SEMI3                = 131, // <For_Stmt> ::= <For> Identifier ':=' Integer <To> Integer <Do> NewLine <Begin> NewLine <Stmt_sequence> NewLine <End> ';'
        RULE_FOR_FOR                                                                                  = 132, // <For> ::= For
        RULE_DO_DO                                                                                    = 133, // <Do> ::= DO
        RULE_TO_TO                                                                                    = 134, // <To> ::= TO
        RULE_TO_DOWNTO                                                                                = 135, // <To> ::= 'Down To'
        RULE_BEGIN_BEGIN                                                                              = 136, // <Begin> ::= begin
        RULE_END_END                                                                                  = 137, // <End> ::= END
        RULE_EXP                                                                                      = 138, // <Exp> ::= <Exp> <Addop> <Term>
        RULE_EXP2                                                                                     = 139, // <Exp> ::= <Term>
        RULE_ADDOP_PLUS                                                                               = 140, // <Addop> ::= '+'
        RULE_ADDOP_MINUS                                                                              = 141, // <Addop> ::= '-'
        RULE_TERM                                                                                     = 142, // <Term> ::= <Term> <Mulop> <Factor>
        RULE_TERM2                                                                                    = 143, // <Term> ::= <Factor>
        RULE_MULOP_TIMES                                                                              = 144, // <Mulop> ::= '*'
        RULE_MULOP_DIV                                                                                = 145, // <Mulop> ::= '/'
        RULE_FACTOR_LPAREN_RPAREN                                                                     = 146, // <Factor> ::= '(' <Exp> ')'
        RULE_FACTOR_SEMI                                                                              = 147, // <Factor> ::= <Values> ';'
        RULE_FACTOR                                                                                   = 148, // <Factor> ::= <Boolean_Expression>
        RULE_VALUES_REAL                                                                              = 149, // <Values> ::= Real
        RULE_VALUES_INTEGER                                                                           = 150, // <Values> ::= Integer
        RULE_VALUES_IDENTIFIER                                                                        = 151, // <Values> ::= Identifier
        RULE_VALUES_CHAR                                                                              = 152, // <Values> ::= Char
        RULE_VALUES_STRING                                                                            = 153, // <Values> ::= String
        RULE_ASSIGNMENT_STMT_COLONEQ                                                                  = 154, // <Assignment_Stmt> ::= <Arg_name> ':=' <Exp>
        RULE_ASSIGNMENT_STMT_COLONEQ2                                                                 = 155, // <Assignment_Stmt> ::= <Arg_name> ':=' <Call_Fun>
        RULE_ASSIGNMENT_STMT_COLONEQ3                                                                 = 156, // <Assignment_Stmt> ::= <Arg_name> ':=' <Read>
        RULE_ASSIGNMENT_STMT_COLONEQ4                                                                 = 157, // <Assignment_Stmt> ::= <Arg_name> ':=' <Read_Line>
        RULE_CALL_FUN_LPAREN_RPAREN_SEMI                                                              = 158, // <Call_Fun> ::= <Fun_Name> '(' <Var_Names> ')' ';'
        RULE_BOOLEAN_EXPRESSION_LPAREN_RPAREN_SEMI                                                    = 159, // <Boolean_Expression> ::= '(' <Arg_name> <And> <Arg_name> ')' ';'
        RULE_BOOLEAN_EXPRESSION_LPAREN_RPAREN_SEMI2                                                   = 160, // <Boolean_Expression> ::= '(' <Arg_name> <Or> <Arg_name> ')' ';'
        RULE_BOOLEAN_EXPRESSION_LPAREN_RPAREN_SEMI3                                                   = 161, // <Boolean_Expression> ::= '(' <Arg_name> <Not> <Arg_name> ')' ';'
        RULE_BOOLEAN_EXPRESSION_LPAREN_RPAREN                                                         = 162, // <Boolean_Expression> ::= '(' <Boolean_Expression> <And> <Boolean_Expression> ')'
        RULE_BOOLEAN_EXPRESSION_LPAREN_RPAREN2                                                        = 163, // <Boolean_Expression> ::= '(' <Boolean_Expression> <Or> <Boolean_Expression> ')'
        RULE_BOOLEAN_EXPRESSION_LPAREN_RPAREN3                                                        = 164, // <Boolean_Expression> ::= '(' <Boolean_Expression> <Not> <Boolean_Expression> ')'
        RULE_AND_AND                                                                                  = 165, // <And> ::= and
        RULE_OR_OR                                                                                    = 166, // <Or> ::= or
        RULE_NOT_NOT                                                                                  = 167, // <Not> ::= Not
        RULE_IF_IF                                                                                    = 168, // <If> ::= if
        RULE_ELSE_ELSE                                                                                = 169, // <Else> ::= else
        RULE_THEN_THEN                                                                                = 170, // <Then> ::= THEN
        RULE_IF_STATMENT_LPAREN_RPAREN                                                                = 171, // <IF_Statment> ::= <If> '(' <Condition> ')' <Then> <Stmt_sequence>
        RULE_IF_STATMENT_LPAREN_RPAREN_NEWLINE_NEWLINE                                                = 172, // <IF_Statment> ::= <If> '(' <Condition> ')' <Then> NewLine <Comment> NewLine <Stmt_sequence>
        RULE_IF_STATMENT_LPAREN_RPAREN_NEWLINE_NEWLINE_NEWLINE                                        = 173, // <IF_Statment> ::= <If> '(' <Condition> ')' <Then> NewLine <Stmt_sequence> NewLine <Else> NewLine <Stmt_sequence>
        RULE_IF_STATMENT_LPAREN_RPAREN_NEWLINE_NEWLINE_NEWLINE_NEWLINE_NEWLINE_NEWLINE_NEWLINE        = 174, // <IF_Statment> ::= <If> '(' <Condition> ')' <Then> NewLine <Comment> NewLine <Stmt_sequence> NewLine <Comment> NewLine <Else> NewLine <Comment> NewLine <Stmt_sequence> NewLine <Comment>
        RULE_IF_STATMENT_LPAREN_RPAREN_NEWLINE_NEWLINE_NEWLINE_NEWLINE_NEWLINE_NEWLINE                = 175, // <IF_Statment> ::= <If> '(' <Condition> ')' <Then> NewLine <Stmt_sequence> NewLine <Comment> NewLine <Else> NewLine <Comment> NewLine <Stmt_sequence> NewLine <Comment>
        RULE_IF_STATMENT_LPAREN_RPAREN_NEWLINE_NEWLINE_NEWLINE_NEWLINE_NEWLINE_NEWLINE2               = 176, // <IF_Statment> ::= <If> '(' <Condition> ')' <Then> NewLine <Comment> NewLine <Stmt_sequence> NewLine <Else> NewLine <Comment> NewLine <Stmt_sequence> NewLine <Comment>
        RULE_IF_STATMENT_LPAREN_RPAREN_NEWLINE_NEWLINE_NEWLINE_NEWLINE_NEWLINE_NEWLINE3               = 177, // <IF_Statment> ::= <If> '(' <Condition> ')' <Then> NewLine <Comment> NewLine <Stmt_sequence> NewLine <Comment> NewLine <Else> NewLine <Stmt_sequence> NewLine <Comment>
        RULE_IF_STATMENT_LPAREN_RPAREN_NEWLINE_NEWLINE_NEWLINE_NEWLINE_NEWLINE_NEWLINE4               = 178, // <IF_Statment> ::= <If> '(' <Condition> ')' <Then> NewLine <Comment> NewLine <Stmt_sequence> NewLine <Comment> NewLine <Else> NewLine <Comment> NewLine <Stmt_sequence>
        RULE_IF_STATMENT_LPAREN_RPAREN_NEWLINE_NEWLINE_NEWLINE_NEWLINE_NEWLINE                        = 179, // <IF_Statment> ::= <If> '(' <Condition> ')' <Then> NewLine <Stmt_sequence> NewLine <Comment> NewLine <Else> NewLine <Comment> NewLine <Stmt_sequence>
        RULE_IF_STATMENT_LPAREN_RPAREN_NEWLINE_NEWLINE_NEWLINE_NEWLINE_NEWLINE2                       = 180, // <IF_Statment> ::= <If> '(' <Condition> ')' <Then> NewLine <Comment> NewLine <Stmt_sequence> NewLine <Else> NewLine <Comment> NewLine <Stmt_sequence>
        RULE_IF_STATMENT_LPAREN_RPAREN_NEWLINE_NEWLINE_NEWLINE_NEWLINE_NEWLINE3                       = 181, // <IF_Statment> ::= <If> '(' <Condition> ')' <Then> NewLine <Comment> NewLine <Stmt_sequence> NewLine <Comment> NewLine <Else> NewLine <Stmt_sequence>
        RULE_IF_STATMENT_LPAREN_RPAREN_NEWLINE_NEWLINE_NEWLINE_NEWLINE_NEWLINE4                       = 182, // <IF_Statment> ::= <If> '(' <Condition> ')' <Then> NewLine <Stmt_sequence> NewLine <Comment> NewLine <Else> NewLine <Stmt_sequence> NewLine <Comment>
        RULE_IF_STATMENT_LPAREN_RPAREN_NEWLINE_NEWLINE_NEWLINE_NEWLINE_NEWLINE5                       = 183, // <IF_Statment> ::= <If> '(' <Condition> ')' <Then> NewLine <Comment> NewLine <Stmt_sequence> NewLine <Else> NewLine <Stmt_sequence> NewLine <Comment>
        RULE_IF_STATMENT_LPAREN_RPAREN_NEWLINE_NEWLINE_NEWLINE_NEWLINE_NEWLINE6                       = 184, // <IF_Statment> ::= <If> '(' <Condition> ')' <Then> NewLine <Stmt_sequence> NewLine <Else> NewLine <Comment> NewLine <Stmt_sequence> NewLine <Comment>
        RULE_WHILE_STMT_NEWLINE_NEWLINE_NEWLINE_SEMI                                                  = 185, // <While_stmt> ::= <While> <Condition> <Do> NewLine <Begin> NewLine <Stmt_sequence> NewLine <End> ';'
        RULE_WHILE_STMT_NEWLINE_NEWLINE_NEWLINE_NEWLINE_NEWLINE_SEMI                                  = 186, // <While_stmt> ::= <While> <Condition> <Do> NewLine <Comment> NewLine <Begin> NewLine <Stmt_sequence> NewLine <Comment> NewLine <End> ';'
        RULE_WHILE_STMT_NEWLINE_NEWLINE_NEWLINE_NEWLINE_NEWLINE_NEWLINE_SEMI                          = 187, // <While_stmt> ::= <While> <Condition> <Do> NewLine <Comment> NewLine <Begin> NewLine <Comment> NewLine <Stmt_sequence> NewLine <Comment> NewLine <End> ';'
        RULE_WHILE_STMT_NEWLINE_NEWLINE_NEWLINE_NEWLINE_NEWLINE_SEMI2                                 = 188, // <While_stmt> ::= <While> <Condition> <Do> NewLine <Begin> NewLine <Comment> NewLine <Stmt_sequence> NewLine <Comment> NewLine <End> ';'
        RULE_WHILE_STMT_NEWLINE_NEWLINE_NEWLINE_NEWLINE_SEMI                                          = 189, // <While_stmt> ::= <While> <Condition> <Do> NewLine <Comment> NewLine <Begin> NewLine <Stmt_sequence> NewLine <End> ';'
        RULE_WHILE_STMT_NEWLINE_NEWLINE_NEWLINE_NEWLINE_NEWLINE_SEMI3                                 = 190, // <While_stmt> ::= <While> <Condition> <Do> NewLine <Comment> NewLine <Begin> NewLine <Comment> NewLine <Stmt_sequence> NewLine <End> ';'
        RULE_WHILE_STMT_NEWLINE_NEWLINE_NEWLINE_NEWLINE_SEMI2                                         = 191, // <While_stmt> ::= <While> <Condition> <Do> NewLine <Begin> NewLine <Comment> NewLine <Stmt_sequence> NewLine <End> ';'
        RULE_WHILE_WHILE                                                                              = 192, // <While> ::= While
        RULE_WORDREAD_READ                                                                            = 193, // <WordRead> ::= read
        RULE_WORDREADLINE_READLN                                                                      = 194, // <WordReadLine> ::= readln
        RULE_SYNTAXREAD_COMMA                                                                         = 195, // <syntaxread> ::= <syntaxread> ',' <Arg_name>
        RULE_SYNTAXREAD                                                                               = 196, // <syntaxread> ::= <Arg_name>
        RULE_READ_LPAREN_RPAREN_SEMI                                                                  = 197, // <Read> ::= <WordRead> '(' <syntaxread> ')' ';'
        RULE_READ_SEMI                                                                                = 198, // <Read> ::= <WordRead> ';'
        RULE_READ_LPAREN_RPAREN                                                                       = 199, // <Read> ::= <WordRead> '(' <syntaxread> ')'
        RULE_READ                                                                                     = 200, // <Read> ::= <WordRead>
        RULE_READ_LINE_LPAREN_RPAREN_SEMI                                                             = 201, // <Read_Line> ::= <WordReadLine> '(' <syntaxread> ')' ';'
        RULE_READ_LINE_SEMI                                                                           = 202, // <Read_Line> ::= <WordReadLine> ';'
        RULE_READ_LINE_LPAREN_RPAREN                                                                  = 203, // <Read_Line> ::= <WordReadLine> '(' <syntaxread> ')'
        RULE_READ_LINE                                                                                = 204, // <Read_Line> ::= <WordReadLine>
        RULE_WORDWRITE_WRITE                                                                          = 205, // <WordWrite> ::= write
        RULE_WORDWRITELINE_WRITELN                                                                    = 206, // <WordWriteLine> ::= writeln
        RULE_SYNTAXWRITE_COMMA                                                                        = 207, // <syntaxwrite> ::= <syntaxwrite> ',' <syntaxwrite>
        RULE_SYNTAXWRITE_STRING                                                                       = 208, // <syntaxwrite> ::= String
        RULE_SYNTAXWRITE                                                                              = 209, // <syntaxwrite> ::= <Arg_name>
        RULE_WRITE_LPAREN_RPAREN_SEMI                                                                 = 210, // <Write> ::= <WordWrite> '(' <syntaxwrite> ')' ';'
        RULE_WRITE_SEMI                                                                               = 211, // <Write> ::= <WordWrite> ';'
        RULE_WRITE_LPAREN_RPAREN                                                                      = 212, // <Write> ::= <WordWrite> '(' <syntaxwrite> ')'
        RULE_WRITE                                                                                    = 213, // <Write> ::= <WordWrite>
        RULE_WRITE_LINE_LPAREN_RPAREN_SEMI                                                            = 214, // <Write_Line> ::= <WordWriteLine> '(' <syntaxwrite> ')' ';'
        RULE_WRITE_LINE_SEMI                                                                          = 215, // <Write_Line> ::= <WordWriteLine> ';'
        RULE_WRITE_LINE_LPAREN_RPAREN                                                                 = 216, // <Write_Line> ::= <WordWriteLine> '(' <syntaxwrite> ')'
        RULE_WRITE_LINE                                                                               = 217, // <Write_Line> ::= <WordWriteLine>
        RULE_PROCEDURE_NEWLINE                                                                        = 218, // <Procedure> ::= <Proc_Sec> NewLine
        RULE_PROCEDURE_NEWLINE_NEWLINE_NEWLINE                                                        = 219, // <Procedure> ::= <Proc_Sec> NewLine <Comment> NewLine <Function> NewLine <Comment>
        RULE_PROCEDURE_NEWLINE_NEWLINE                                                                = 220, // <Procedure> ::= <Proc_Sec> NewLine <Comment> NewLine <Function>
        RULE_PROCEDURE_NEWLINE_NEWLINE2                                                               = 221, // <Procedure> ::= <Proc_Sec> NewLine <Function> NewLine <Comment>
        RULE_PROC_SEC_IDENTIFIER_NEWLINE                                                              = 222, // <Proc_Sec> ::= <Proc> Identifier <Proc_ArgDec> NewLine <Proc_Content>
        RULE_PROC_ARGDEC_NEWLINE                                                                      = 223, // <Proc_ArgDec> ::= <Variable_Sec> NewLine <Proc_ArgDec>
        RULE_PROC_ARGDEC_NEWLINE2                                                                     = 224, // <Proc_ArgDec> ::= <Fun_Declaration> NewLine <Proc_ArgDec>
        RULE_PROC_ARGDEC                                                                              = 225, // <Proc_ArgDec> ::= 
        RULE_PROC_PROCEDURE                                                                           = 226, // <Proc> ::= Procedure
        RULE_PROC_CONTENT_NEWLINE_NEWLINE_NEWLINE_NEWLINE_NEWLINE_SEMI                                = 227, // <Proc_Content> ::= <Stmt_sequence> <Comment> NewLine <Begin> NewLine <Comment> NewLine <Stmt_sequence> NewLine <Comment> NewLine <End> ';'
        RULE_PROC_CONTENT_NEWLINE_NEWLINE_NEWLINE_SEMI                                                = 228, // <Proc_Content> ::= <Stmt_sequence> <Comment> NewLine <Begin> NewLine <Stmt_sequence> NewLine <End> ';'
        RULE_PROC_CONTENT_NEWLINE_NEWLINE_NEWLINE_SEMI2                                               = 229, // <Proc_Content> ::= <Stmt_sequence> <Begin> NewLine <Comment> NewLine <Stmt_sequence> NewLine <End> ';'
        RULE_PROC_CONTENT_NEWLINE_NEWLINE_NEWLINE_SEMI3                                               = 230, // <Proc_Content> ::= <Stmt_sequence> <Begin> NewLine <Stmt_sequence> NewLine <Comment> NewLine <End> ';'
        RULE_PROC_CONTENT_NEWLINE_NEWLINE_NEWLINE_NEWLINE_SEMI                                        = 231, // <Proc_Content> ::= <Stmt_sequence> <Comment> NewLine <Begin> NewLine <Comment> NewLine <Stmt_sequence> NewLine <End> ';'
        RULE_PROC_CONTENT_NEWLINE_NEWLINE_NEWLINE_NEWLINE_SEMI2                                       = 232, // <Proc_Content> ::= <Stmt_sequence> <Begin> NewLine <Comment> NewLine <Stmt_sequence> NewLine <Comment> NewLine <End> ';'
        RULE_PROC_CONTENT_NEWLINE_NEWLINE_NEWLINE_NEWLINE_SEMI3                                       = 233, // <Proc_Content> ::= <Stmt_sequence> <Comment> NewLine <Begin> NewLine <Stmt_sequence> NewLine <Comment> NewLine <End> ';'
        RULE_MAIN_BLOCK_NEWLINE_NEWLINE_NEWLINE_NEWLINE                                               = 234, // <Main_Block> ::= <Begin> NewLine <Comment> NewLine <Stmt_sequence> NewLine <Comment> NewLine <End_Main>
        RULE_MAIN_BLOCK_NEWLINE_NEWLINE_NEWLINE                                                       = 235, // <Main_Block> ::= <Begin> NewLine <Stmt_sequence> NewLine <Comment> NewLine <End_Main>
        RULE_MAIN_BLOCK_NEWLINE_NEWLINE_NEWLINE2                                                      = 236, // <Main_Block> ::= <Begin> NewLine <Comment> NewLine <Stmt_sequence> NewLine <End_Main>
        RULE_END_MAIN_ENDDOT                                                                          = 237  // <End_Main> ::= 'end.'
    };

    public class MyParser
    {
        private LALRParser parser;
        ListBox Errors;
       
        bool flag_readType = false;
        int count_type = 1;
        List<string> reservedWords = new List<string>();

        List<string> Variables = new List<string>();
        List<string> Variables_Types = new List<string>();

        List<string> constant = new List<string>();

       public List<string> Semantic_Errors = new List<string>();

        List<string> Variable_In_Function = new List<string>();
        List<string> Fun_Variable_Types = new List<string>();

        List<string> Variable_In_Procedure = new List<string>();
        List<string> Proc_Variable_Types = new List<string>();

        List<string> Variables_In_Main = new List<string>();
        List<string> Main_Variable_Types = new List<string>();

        string Flag = "";
        string Flag_Assignment = "";

        List<string> One_Block = new List<string>();
        List<string> Constant_types = new List<string>();

        bool Flag_Function = false;
        bool Flag_Procedure = false;
        bool Flag_Main = false;

        bool Flag_Comment = false;

        List<string> Types = new List<string>();
        List<string> ValuesType = new List<string>();

        //===================================================================

        public MyParser(string filename)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open,
                                               FileAccess.Read,
                                               FileShare.Read);
            Init(stream);
            stream.Close();
        }

        public MyParser(string filename, ListBox Errors)
        {
            
            FileStream stream = new FileStream(filename,
                                               FileMode.Open,
                                               FileAccess.Read,
                                               FileShare.Read);
            Init(stream);
            stream.Close();
            this.Errors = Errors;

            Types.Add("integer");
            Types.Add("string");
            Types.Add("char");
            Types.Add("boolean");
            Types.Add("real");

            ValuesType.Add("Integer_Number");
            ValuesType.Add("Real_Number");
            ValuesType.Add("String_Value");
            ValuesType.Add("Char_Value");
            
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);

            
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;
            parser.OnShift += new LALRParser.ShiftHandler(ShiftEvent);
            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
            //add reserved word
            reservedWords.Add("readln");
            reservedWords.Add("read");
            reservedWords.Add("write");
            reservedWords.Add("writeln");
            reservedWords.Add("if");
            reservedWords.Add("then");
            reservedWords.Add("else");
            reservedWords.Add("begin");
            reservedWords.Add("end");
            reservedWords.Add("then");
            reservedWords.Add("function");
            reservedWords.Add("goto");
            reservedWords.Add("break");
            reservedWords.Add("continue");
            reservedWords.Add("program");
            reservedWords.Add("uses");
            reservedWords.Add("var");
            reservedWords.Add("const");
            reservedWords.Add("procedure");
            reservedWords.Add("to");
            reservedWords.Add("and");
            reservedWords.Add("div");
            reservedWords.Add("file");
            reservedWords.Add("in");
            reservedWords.Add("of");
            reservedWords.Add("record");
            reservedWords.Add("type");
            reservedWords.Add("array");
            reservedWords.Add("do");
            reservedWords.Add("for");
            reservedWords.Add("label");
            reservedWords.Add("or");
            reservedWords.Add("repeat");
            reservedWords.Add("until");
            reservedWords.Add("downto");
            reservedWords.Add("mod");
            reservedWords.Add("set");
            reservedWords.Add("case");
            reservedWords.Add("pracked");
            reservedWords.Add("nil");
            reservedWords.Add("while");
            reservedWords.Add("not");
            reservedWords.Add("with");
        }

        //================================= Shift Event Is Here ==================================
        private void ShiftEvent(LALRParser parser, ShiftEventArgs args)
        {
            if (args.Token.Symbol.Name == "Identifier")
            {
                One_Block.Add(args.Token.Text.ToLower());
            }

            #region Clear Any Thing
            if (args.Token.Text.ToLower() == "program ")
            {
                One_Block.Clear();
                Variables.Clear();
                Variable_In_Function.Clear();
                Variable_In_Procedure.Clear();
                Variables_In_Main.Clear();
                Variables_Types.Clear();
                Fun_Variable_Types.Clear();
                constant.Clear();
                Proc_Variable_Types.Clear();
                Main_Variable_Types.Clear();
                Flag = "";
                Flag_Assignment = "";
                Flag_Comment = false;
                Flag_Function = false;
                Flag_Main = false;
                flag_readType = false;
                Semantic_Errors.Clear();
                count_type = 1;
            }

            #endregion

            #region It's In Comment
            if (args.Token.Text == "{" || args.Token.Text == "{*")
            {
                Flag_Comment = true;
            }
            else if (args.Token.Text == "}" || args.Token.Text == "*}")
            {
                Flag_Comment = false;
            }

            #endregion

            else if (!Flag_Comment)
            {

                #region Check what Is the Block

                if (args.Token.Text.ToLower() == "function")
                {
                    Flag_Function = true;
                    Flag_Main = false;
                    Flag_Procedure = false;
                }
                else if (args.Token.Text.ToLower() == "procedure")
                {
                    Flag_Procedure = true;
                    Flag_Function = false;
                    Flag_Main = false;
                }
                else if (args.Token.Text.ToLower() == "begin" && !Flag_Procedure && !Flag_Function)
                {
                    Flag_Main = true;
                }
                #endregion

                #region Variable OR Constant
                // Const Done
                if (args.Token.Text.ToLower() == "const")
                {
                    if (!Flag_Main && !Flag_Procedure && !Flag_Function)
                    {
                        Flag = "c";
                    }
                }
               else if (args.Token.Text.ToLower() == "var")
                {
                    if (!Flag_Function && !Flag_Procedure && !Flag_Main)
                    {
                        Flag = "v";
                    }
                    if ( Flag_Procedure)
                    {
                        Flag = "pv";
                    }
                    if (Flag_Function)
                    {
                        Flag = "fv";
                    }
                    
                }
                #endregion

                #region It's Constant
                else if (args.Token.Symbol.Name == "Identifier" && Flag == "c")
                {
                    //  may = args.Token.Text;
                    if (!reservedWords.Contains(args.Token.Text.ToLower()))
                    {
                        if (!Variables.Contains(args.Token.Text.ToLower()))
                        {
                            if (!constant.Contains(args.Token.Text.ToLower()))
                            {
                                constant.Add(args.Token.Text.ToLower());
                            }
                            else
                                Semantic_Errors.Add("This Constant ( " + args.Token.Text + ") Is Already Exist As a Constant!! /");
                        }
                        else
                            Semantic_Errors.Add("This Constant ( " + args.Token.Text + ") Is Already Exist As a Variable!! /");
                    }
                    else
                        Semantic_Errors.Add("Constant Variable " + args.Token.Text + " Is a Reserved Word .. /");

                }
                #endregion

                #region Get Count Of Variables
                else if (args.Token.Text == ",")
                {
                    count_type++;
                }
                else if (args.Token.Text == ";")
                {
                    count_type = 1;
                    Flag_Assignment = "";
                    //Flag = "";
                }
                #endregion

                #region Its's Variable
                //========================================================================

                #region Global Variable Here

                else if (args.Token.Text == ":")
                {
                    flag_readType = true;
                    //                  Global Variable
                    if (Flag == "v")
                    {
                        for (int i = 1; i <= count_type; i++)
                        {
                            if (!reservedWords.Contains(One_Block[One_Block.Count - i].ToLower()))
                            {
                                if (!constant.Contains(One_Block[One_Block.Count - i].ToLower()))
                                {
                                    if (!Variables.Contains(One_Block[One_Block.Count - i].ToLower()))
                                    {
                                        Variables.Add(One_Block[One_Block.Count - i].ToLower());
                                    }
                                    else
                                        Semantic_Errors.Add("This Variable ( " + One_Block[One_Block.Count - i] + ") Is Already Exist As a Variable!!");
                                }
                                else
                                    Semantic_Errors.Add("This Variable ( " + One_Block[One_Block.Count - i] + ") Is Already Exist As a Constant!!");
                            }
                            else
                                Semantic_Errors.Add("Constant Variable " + One_Block[One_Block.Count - i] + " Is a Reserved Word ..");
                        }
                    }

                #endregion

                    #region Function Variable
                    //                         In Function
                    else if (Flag == "fv")
                    {
                        for (int i = 1; i <= count_type; i++)
                        {
                            if (!reservedWords.Contains(One_Block[One_Block.Count - i].ToLower()))
                            {
                                if (!constant.Contains(One_Block[One_Block.Count - i].ToLower()))
                                {
                                    if (!Variables.Contains(One_Block[One_Block.Count - i].ToLower()))
                                    {
                                        if (!Variable_In_Function.Contains(One_Block[One_Block.Count - i].ToLower()))
                                        {
                                            Variable_In_Function.Add(One_Block[One_Block.Count - i].ToLower());
                                        }
                                        else
                                            Semantic_Errors.Add("Variable " + One_Block[One_Block.Count - i] + " Is Already Exist!!");
                                    }
                                    else
                                        Semantic_Errors.Add("This Variable ( " + One_Block[One_Block.Count - i] + ") Is Already Exist As a Variable!!");
                                }
                                else
                                    Semantic_Errors.Add("This Variable ( " + One_Block[One_Block.Count - i] + ") Is Already Exist As a Constant!!");
                            }
                            else
                                Semantic_Errors.Add("Constant Variable " + One_Block[One_Block.Count - i] + " Is a Reserved Word ..");
                        }
                    }
                    #endregion

                    #region Procedure Variable
                    //                         In Procedure
                    else if (Flag == "pv")
                    {
                        for (int i = 1; i <= count_type; i++)
                        {
                            if (!reservedWords.Contains(One_Block[One_Block.Count - i].ToLower()))
                            {
                                if (!constant.Contains(One_Block[One_Block.Count - i].ToLower()))
                                {
                                    if (!Variables.Contains(One_Block[One_Block.Count - i].ToLower()))
                                    {
                                        if (!Variable_In_Procedure.Contains(One_Block[One_Block.Count - i].ToLower()))
                                        {
                                            Variable_In_Procedure.Add(One_Block[One_Block.Count - i].ToLower());
                                        }
                                        else
                                            Semantic_Errors.Add("Variable " + One_Block[One_Block.Count - i] + " Is Already Exist!!");
                                    }
                                    else
                                        Semantic_Errors.Add("This Variable ( " + One_Block[One_Block.Count - i] + ") Is Already Exist As a Variable!!");
                                }
                                else
                                    Semantic_Errors.Add("This Variable ( " + One_Block[One_Block.Count - i] + ") Is Already Exist As a Constant!!");
                            }
                            else
                                Semantic_Errors.Add("Constant Variable " + One_Block[One_Block.Count - i] + " Is a Reserved Word ..");
                        }
                    }
                    #endregion
                }
                //=========================================================================
                #endregion

                #region  Assignment Statement Begin

                //          Assignment Statement In main Block 
                else if (args.Token.Text == ":=" && Flag_Main)
                {
                    Flag_Assignment = "a_m";
                    if (!Variables.Contains(One_Block[One_Block.Count - 1].ToLower()))
                    {
                        Semantic_Errors.Add("Variable " + One_Block[One_Block.Count - 1] + " Is Not Declared !!");
                    }
                }
                //          Assignment Statement In Function Block 
                else if (args.Token.Text == ":=" && Flag_Function)
                {
                    Flag_Assignment = "a_f";
                    if (!Variables.Contains(One_Block[One_Block.Count - 1].ToLower()))
                    {
                        if (!Variable_In_Function.Contains(One_Block[One_Block.Count - 1].ToLower()))
                        {
                            Semantic_Errors.Add("Variable " + One_Block[One_Block.Count - 1] + " Is Not Declared !!");
                        }
                    }
                }
                //          Assignment Statement In Procedure Block 
                else if (args.Token.Text == ":=" && Flag_Procedure)
                {
                    Flag_Assignment = "a_p";
                    if (!Variables.Contains(One_Block[One_Block.Count - 1].ToLower()))
                    {
                        if (!Variable_In_Procedure.Contains(One_Block[One_Block.Count - 1].ToLower()))
                        {
                            Semantic_Errors.Add("Variable " + One_Block[One_Block.Count - 1] + " Is Not Declared !!");
                        }
                    }
                }

                #endregion

                #region If Assign Values
                int TypeIndex = -1;
                string TempType = "";
                if (ValuesType.Contains(args.Token.Symbol.Name))
                {
                    TypeIndex = ValuesType.IndexOf(args.Token.Symbol.Name);
                    // string TempType = "";
                    if (TypeIndex == 0)
                    {
                        TempType = "integer";
                    }
                    else if (TypeIndex == 1)
                    {
                        TempType = "real";
                    }
                    else if (TypeIndex == 2)
                    {
                        TempType = "string";
                    }
                    else if (TypeIndex == 3)
                    {
                        TempType = "real";
                    }
                }
                #endregion


                #region Begin Storing Types For Variables
               
                else if (Types.Contains(TempType))
                {
                    //               Types For Constants
                    for (int i = 1; i <= count_type; i++)
                    {
                        Constant_types.Add(TempType);
                    }
                    //===================This Section For Glopal Variable=====================
                    if (flag_readType && Flag == "v")
                    {
                        for (int i = 1; i <= count_type; i++)
                        {
                            Variables_Types.Add(args.Token.Text.ToLower());
                        }
                    }

                   //===================This Section For Function Variable===================
                    else if (flag_readType && Flag == "fv")
                    {
                        for (int i = 1; i <= count_type; i++)
                        {
                            Fun_Variable_Types.Add(args.Token.Text.ToLower());
                        }
                    }
                    //===================This Section For Procedure Variable==================
                    else if (flag_readType && Flag == "pv")
                    {
                        for (int i = 1; i <= count_type; i++)
                        {
                            Proc_Variable_Types.Add(args.Token.Text.ToLower());
                        }
                    }
                }
                //===============================================================================
                #endregion

             


                #region Assignment In Main

                if (Flag_Assignment == "a_m" && args.Token.Text != ":=")
                {
                    if (args.Token.Symbol.Name == "Identifier")
                    {
                        if (!constant.Contains(One_Block[One_Block.Count - 2].ToLower()))
                        {
                            if (Variables.Contains(One_Block[One_Block.Count - 2].ToLower()) && Variables.Contains(args.Token.Text.ToLower()))
                            {
                                int Index1 = Variables.IndexOf(args.Token.Text.ToLower());
                                int Index2 = Variables.IndexOf(One_Block[One_Block.Count - 2].ToLower());
                                if (Variables_Types[Index1] != Variables_Types[Index2])
                                {
                                    Semantic_Errors.Add("Can't Assign Two Different Types!!");
                                }
                            }
                            else if (Variables.Contains(One_Block[One_Block.Count - 2].ToLower()) && constant.Contains(args.Token.Text.ToLower()))
                            {
                                int Index1 = constant.IndexOf(args.Token.Text.ToLower());
                                int Index2 = Variables.IndexOf(One_Block[One_Block.Count - 2].ToLower());
                                if (Constant_types[Index1] != Variables_Types[Index2])
                                {
                                    Semantic_Errors.Add("Can't Assign Two Different Types!!");
                                }
                            }
                            else
                                Semantic_Errors.Add("Identifier" + args.Token.Text.ToLower() + " Is Not Exist!!");
                        }
                        else
                            Semantic_Errors.Add("Can't Reassign the constants !!");

                    }

                    else
                    {
                        if (ValuesType.Contains(args.Token.Symbol.Name))
                        {
                            if (!constant.Contains(One_Block[One_Block.Count - 1].ToLower()))
                            {
                                if (Variables.Contains(One_Block[One_Block.Count - 1].ToLower()))
                                {
                                    int Index = Variables.IndexOf(One_Block[One_Block.Count - 1].ToLower());

                                    if (Variables_Types[Index].ToLower() !=  TempType )
                                    {
                                        Semantic_Errors.Add("Can't Assign Two Different Types!!");
                                    }
                                }
                                else
                                    Semantic_Errors.Add("Identifier" + args.Token.Text.ToLower() + " Is Not Exist!!");
                            }
                            else
                                Semantic_Errors.Add("Can't Reassign the constants !!");
                        }
                    }
                }
                #endregion

                #region Assigment In Function

                else if (Flag_Assignment == "a_f" && args.Token.Text != ":=")
                {
                    /////////////////////////////////////////////////
                    if (args.Token.Symbol.Name == "Identifier")
                    {
                        if (!constant.Contains(One_Block[One_Block.Count - 2].ToLower()))
                        {
                            if (Variables.Contains(One_Block[One_Block.Count - 2].ToLower()) && Variables.Contains(args.Token.Text.ToLower()))
                            {
                                int Index1 = Variables.IndexOf(args.Token.Text.ToLower());
                                int Index2 = Variables.IndexOf(One_Block[One_Block.Count - 2].ToLower());
                                if (Variables_Types[Index1] != Variables_Types[Index2])
                                {
                                    Semantic_Errors.Add("Can't Assign Two Different Types!!");
                                }
                            }
                            else if (Variable_In_Function.Contains(One_Block[One_Block.Count - 2].ToLower()) && Variable_In_Function.Contains(args.Token.Text.ToLower()))
                            {
                                int Index1 = Variable_In_Function.IndexOf(args.Token.Text.ToLower());
                                int Index2 = Variable_In_Function.IndexOf(One_Block[One_Block.Count - 2].ToLower());
                                if (Fun_Variable_Types[Index1] != Fun_Variable_Types[Index2])
                                {
                                    Semantic_Errors.Add("Can't Assign Two Different Types!!");
                                }
                            }
                            else if (Variable_In_Function.Contains(One_Block[One_Block.Count - 2].ToLower()) && Variables.Contains(args.Token.Text.ToLower()))
                            {
                                int Index1 = Variables.IndexOf(args.Token.Text.ToLower());
                                int Index2 = Variable_In_Function.IndexOf(One_Block[One_Block.Count - 2].ToLower());
                                if (Variables_Types[Index1] != Fun_Variable_Types[Index2])
                                {
                                    Semantic_Errors.Add("Can't Assign Two Different Types!!");
                                }
                            }
                            else if (Variables.Contains(One_Block[One_Block.Count - 2].ToLower()) && Variable_In_Function.Contains(args.Token.Text.ToLower()))
                            {
                                int Index1 = Variable_In_Function.IndexOf(args.Token.Text.ToLower());
                                int Index2 = Variables.IndexOf(One_Block[One_Block.Count - 2].ToLower());
                                if (Fun_Variable_Types[Index1] != Variables_Types[Index2])
                                {
                                    Semantic_Errors.Add("Can't Assign Two Different Types!!");
                                }
                            }
                            else if (constant.Contains(args.Token.Text.ToLower()))
                            {
                                int Index1 = constant.IndexOf(args.Token.Text.ToLower());
                                int Index2 = Variables.IndexOf(One_Block[One_Block.Count - 2].ToLower());
                                if (Index2 == -1)
                                {
                                    Index2 = Variable_In_Function.IndexOf(One_Block[One_Block.Count - 2].ToLower());
                                    if (Constant_types[Index1] != Fun_Variable_Types[Index2])
                                    {
                                        Semantic_Errors.Add("Can't Assign Two Different Types!!");
                                    }

                                }
                                else
                                {
                                    if (Constant_types[Index1] != Variables_Types[Index2])
                                    {
                                        Semantic_Errors.Add("Can't Assign Two Different Types!!");
                                    }
                                }
                            }
                            else
                                Semantic_Errors.Add("Identifier" + args.Token.Text.ToLower() + " Is Not Exist!!");

                        }
                    }

                    else
                    {
                        if (Types.Contains(args.Token.Symbol.Name))
                        {
                            if (!constant.Contains(One_Block[One_Block.Count - 1].ToLower()))
                            {
                                if (Variables.Contains(One_Block[One_Block.Count - 1].ToLower()) )
                                {
                                    int Index = Variables.IndexOf(One_Block[One_Block.Count - 1].ToLower());
                                    if (Variables_Types[Index].ToLower() != TempType)
                                    {
                                        Semantic_Errors.Add("Can't Assign Two Different Types!!");
                                    }
                                }
                                else if (Variable_In_Function.Contains(One_Block[One_Block.Count - 1].ToLower()))
                                {
                                    int Index = Variable_In_Function.IndexOf(One_Block[One_Block.Count - 1].ToLower());
                                    if (Fun_Variable_Types[Index].ToLower() != TempType)
                                    {
                                        Semantic_Errors.Add("Can't Assign Two Different Types!!");
                                    }
                                }
                                else
                                    Semantic_Errors.Add("Identifier" + args.Token.Text.ToLower() + " Is Not Exist!!");
                            }
                            else
                                Semantic_Errors.Add("Can't Reassign the constants !!");
                        }
                    }
                    ////////////////////////////////////////////////
                }

                #endregion

                #region Assignment In Procedure
                else if (Flag_Assignment == "a_p" && args.Token.Text != ":=")
                {
                    /////////////////////////////////////////////////
                    if (args.Token.Symbol.Name == "Identifier")
                    {
                        if (!constant.Contains(One_Block[One_Block.Count - 2].ToLower()))
                        {
                            if (Variables.Contains(One_Block[One_Block.Count - 2].ToLower()) && Variables.Contains(args.Token.Text.ToLower()))
                            {
                                int Index1 = Variables.IndexOf(args.Token.Text.ToLower());
                                int Index2 = Variables.IndexOf(One_Block[One_Block.Count - 2].ToLower());
                                if (Variables_Types[Index1] != Variables_Types[Index2])
                                {
                                    Semantic_Errors.Add("Can't Assign Two Different Types!!");
                                }
                            }
                            else if (Variable_In_Procedure.Contains(One_Block[One_Block.Count - 2].ToLower()) && Variable_In_Procedure.Contains(args.Token.Text.ToLower()))
                            {
                                int Index1 = Variable_In_Procedure.IndexOf(args.Token.Text.ToLower());
                                int Index2 = Variable_In_Procedure.IndexOf(One_Block[One_Block.Count - 2].ToLower());
                                if (Fun_Variable_Types[Index1] != Fun_Variable_Types[Index2])
                                {
                                    Semantic_Errors.Add("Can't Assign Two Different Types!!");
                                }
                            }
                            else if (Variable_In_Procedure.Contains(One_Block[One_Block.Count - 2].ToLower()) && Variables.Contains(args.Token.Text.ToLower()))
                            {
                                int Index1 = Variables.IndexOf(args.Token.Text.ToLower());
                                int Index2 = Variable_In_Procedure.IndexOf(One_Block[One_Block.Count - 2].ToLower());
                                if (Variables_Types[Index1] != Fun_Variable_Types[Index2])
                                {
                                    Semantic_Errors.Add("Can't Assign Two Different Types!!");
                                }
                            }
                            else if (Variables.Contains(One_Block[One_Block.Count - 2].ToLower()) && Variable_In_Procedure.Contains(args.Token.Text.ToLower()))
                            {
                                int Index1 = Variable_In_Procedure.IndexOf(args.Token.Text.ToLower());
                                int Index2 = Variables.IndexOf(One_Block[One_Block.Count - 2].ToLower());
                                if (Fun_Variable_Types[Index1] != Variables_Types[Index2])
                                {
                                    Semantic_Errors.Add("Can't Assign Two Different Types!!");
                                }
                            }
                                /////////////////////////////////
                          else if (constant.Contains(args.Token.Text.ToLower()))
                            {
                                int Index1 = constant.IndexOf(args.Token.Text.ToLower());
                                int Index2 = Variables.IndexOf(One_Block[One_Block.Count - 2].ToLower());
                                if (Index2 == -1)
                                {
                                    Index2 = Variable_In_Function.IndexOf(One_Block[One_Block.Count - 2].ToLower());
                                    if (Constant_types[Index1] != Fun_Variable_Types[Index2])
                                    {
                                        Semantic_Errors.Add("Can't Assign Two Different Types!!");   
                                    }
                                   
                                }
                                else
                                {
                                    if (Constant_types[Index1] != Variables_Types[Index2])
                                    {
                                        Semantic_Errors.Add("Can't Assign Two Different Types!!");
                                    }
                               }
                            }
                         
                                ///////////////////////////////

                            else
                                Semantic_Errors.Add("Identifier" + args.Token.Text.ToLower() + " Is Not Exist!!");
                        }
                        else
                            Semantic_Errors.Add("Can't Reassign the constants !!");
                    
                    }
                    else
                    {
                        if (Types.Contains(args.Token.Symbol.Name))
                        {
                            if (!constant.Contains(One_Block[One_Block.Count - 1].ToLower()))
                            {
                                if (Variables.Contains(One_Block[One_Block.Count - 1].ToLower()))
                                {
                                    int Index = Variables.IndexOf(One_Block[One_Block.Count - 1].ToLower());
                                    if (Variables_Types[Index].ToLower() != TempType)
                                    {
                                        Semantic_Errors.Add("Can't Assign Two Different Types!!");
                                    }
                                }
                                else if (Variable_In_Procedure.Contains(One_Block[One_Block.Count - 1].ToLower()))
                                {
                                    int Index = Variable_In_Procedure.IndexOf(One_Block[One_Block.Count - 1].ToLower());
                                    if (Proc_Variable_Types[Index].ToLower() != TempType)
                                    {
                                        Semantic_Errors.Add("Can't Assign Two Different Types!!");
                                    }
                                }
                                else
                                    Semantic_Errors.Add("Identifier" + args.Token.Text.ToLower() + " Is Not Exist!!");
                            }
                            else
                                Semantic_Errors.Add("Can't Reassign the constants !!");
                        }
                    }
                }
                #endregion


            }
        }

        public void Parse(string source)
        {
            NonterminalToken token = parser.Parse(source);
            if (token != null)
            {
                Object obj = CreateObject(token);
                //todo: Use your object any way you like
            }
        }

        private Object CreateObject(Token token)
        {
            if (token is TerminalToken)
                return CreateObjectFromTerminal((TerminalToken)token);
            else
                return CreateObjectFromNonterminal((NonterminalToken)token);
        }

        private Object CreateObjectFromTerminal(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //Whitespace
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUS :
                //'-'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_AMP :
                //'&'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LPAREN :
                //'('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RPAREN :
                //')'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMES :
                //'*'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMMA :
                //','
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COLON :
                //':'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COLONEQ :
                //':='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SEMI :
                //';'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LBRACE :
                //'{'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PIPE :
                //'|'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACE :
                //'}'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LT :
                //'<'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LTEQ :
                //'<='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LTGT :
                //'<>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQ :
                //'='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GT :
                //'>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GTEQ :
                //'>='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_AND :
                //and
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BEGIN :
                //begin
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BOOLEAN :
                //boolean
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BREAK :
                //Break
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CHAR :
                //Char
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CHARACTER :
                //character
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONST :
                //const
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONTINUE :
                //Continue
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CURLYBRACET :
                //CurlyBracet
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DO :
                //DO
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DOWNTO :
                //'Down To'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSE :
                //else
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_END :
                //END
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ENDDOT :
                //'end.'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FALSE :
                //false
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FLOAT :
                //Float
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR :
                //For
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNCTION :
                //function
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GOTO :
                //GoTo
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IDENTIFIER :
                //Identifier
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF :
                //if
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INT :
                //int
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INTEGER :
                //Integer
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LABEL :
                //Label
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NEWLINE :
                //NewLine
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NOT :
                //Not
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OR :
                //or
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROCEDURE :
                //Procedure
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROGRAM :
                //'program '
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_READ :
                //read
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_READLN :
                //readln
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_REAL :
                //Real
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_REPEAT :
                //Repeat
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SINGLEQOUT :
                //Singleqout
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRING :
                //String
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_THEN :
                //THEN
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TO :
                //TO
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TRUE :
                //true
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_UNTILL :
                //Untill
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_USES :
                //uses
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VAR :
                //var
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE :
                //While
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WRITE :
                //write
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WRITELN :
                //writeln
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ADDEXP :
                //<Add Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ADDOP :
                //<Addop>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_AND2 :
                //<And>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ARG_NAME :
                //<Arg_name>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ARGUMENT_SEC :
                //<Argument_Sec>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ASSIGNMENT_STMT :
                //<Assignment_Stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BEGIN2 :
                //<Begin>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BOOLEAN_EXPRESSION :
                //<Boolean_Expression>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BR :
                //<Br>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BREAK2 :
                //<Break>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CALL_FUN :
                //<Call_Fun>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMMENT :
                //<Comment>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMMENT_STRING :
                //<Comment_String>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CON :
                //<Con>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONDITION :
                //<Condition>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONST2 :
                //<Const>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONST_VAR :
                //<Const_Var>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONSTANT :
                //<Constant>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONSTANT_VALUE :
                //<constant_value>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONTINUE2 :
                //<Continue>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DO2 :
                //<Do>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSE2 :
                //<Else>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_END2 :
                //<End>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_END_MAIN :
                //<End_Main>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXP :
                //<Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPRESSION :
                //<Expression>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FACTOR :
                //<Factor>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR2 :
                //<For>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR_STMT :
                //<For_Stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUN :
                //<Fun>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUN_DECLARATION :
                //<Fun_Declaration>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUN_NAME :
                //<Fun_Name>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUN_SEC :
                //<Fun_Sec>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNCTION2 :
                //<Function>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNCTION_CONTENT :
                //<Function_Content>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GO :
                //<Go>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GO_TO :
                //<Go_To>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF2 :
                //<If>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF_STATMENT :
                //<IF_Statment>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LABEL_GO :
                //<Label_go>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LABEL_STMT :
                //<Label_Stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MAIN_BLOCK :
                //<Main_Block>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MULOP :
                //<Mulop>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MULTEXP :
                //<MultExp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NEGATEEXP :
                //<Negate Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NL :
                //<nl>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NLOPT :
                //<nl Opt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NOT2 :
                //<Not>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ONELINE :
                //<OneLine>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OP :
                //<OP>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OR2 :
                //<Or>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PRO :
                //<Pro>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROC :
                //<Proc>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROC_ARGDEC :
                //<Proc_ArgDec>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROC_CONTENT :
                //<Proc_Content>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROC_SEC :
                //<Proc_Sec>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROCEDURE2 :
                //<Procedure>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROGRAM2 :
                //<Program>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROGRAM_NAME :
                //<Program_Name>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROGRAM_SEC :
                //<Program_Sec>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_READ2 :
                //<Read>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_READ_LINE :
                //<Read_Line>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_REP :
                //<Rep>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_REPEAT_STMT :
                //<Repeat_Stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SEND_TO :
                //<Send_To>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STMT :
                //<Stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STMT_SEQUENCE :
                //<Stmt_sequence>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SYNTAXREAD :
                //<syntaxread>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SYNTAXWRITE :
                //<syntaxwrite>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TERM :
                //<Term>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TF :
                //<TF>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_THEN2 :
                //<Then>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TO2 :
                //<To>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TYPE :
                //<type>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_UNTILL2 :
                //<Untill>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_USES2 :
                //<Uses>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_USES_COMMAND :
                //<Uses_Command>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VALUE :
                //<Value>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VALUES :
                //<Values>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VAR_DEC :
                //<Var_Dec>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VAR_NAMES :
                //<Var_Names>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VAR_WORD :
                //<Var_Word>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VARIABLE_SEC :
                //<Variable_Sec>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE2 :
                //<While>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE_STMT :
                //<While_stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WORDREAD :
                //<WordRead>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WORDREADLINE :
                //<WordReadLine>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WORDWRITE :
                //<WordWrite>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WORDWRITELINE :
                //<WordWriteLine>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WRITE2 :
                //<Write>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WRITE_LINE :
                //<Write_Line>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_NL_NEWLINE :
                //<nl> ::= NewLine <nl>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NL_NEWLINE2 :
                //<nl> ::= NewLine
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NLOPT_NEWLINE :
                //<nl Opt> ::= NewLine <nl Opt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NLOPT :
                //<nl Opt> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PRO :
                //<Pro> ::= <Program_Name>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PROGRAM_NAME_SEMI_NEWLINE :
                //<Program_Name> ::= <Comment> <Program_Sec> ';' NewLine <Uses_Command>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PROGRAM_NAME_SEMI_NEWLINE_NEWLINE :
                //<Program_Name> ::= <Program_Sec> ';' NewLine <Comment> NewLine <Uses_Command>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PROGRAM_NAME_SEMI_NEWLINE2 :
                //<Program_Name> ::= <Program_Sec> ';' NewLine <Uses_Command>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PROGRAM_SEC_IDENTIFIER :
                //<Program_Sec> ::= <Program> Identifier
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PROGRAM_PROGRAM :
                //<Program> ::= 'program '
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMMENT_LBRACE_TIMES_TIMES_RBRACE :
                //<Comment> ::= '{' '*' <Comment_String> '*' '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMMENT_LBRACE_RBRACE :
                //<Comment> ::= '{' <OneLine> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMMENT_STRING_STRING :
                //<Comment_String> ::= String <nl Opt> <Comment_String>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMMENT_STRING :
                //<Comment_String> ::= <nl Opt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ONELINE_STRING :
                //<OneLine> ::= String
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_USES_COMMAND_NEWLINE_IDENTIFIER_SEMI :
                //<Uses_Command> ::= <Uses> NewLine Identifier ';' <Comment> <Uses_Command> <Const>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_USES_COMMAND_NEWLINE_IDENTIFIER_SEMI2 :
                //<Uses_Command> ::= <Uses> NewLine Identifier ';' <Uses_Command> <Const>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_USES_COMMAND :
                //<Uses_Command> ::= <Const>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_USES_COMMAND_IDENTIFIER_NEWLINE :
                //<Uses_Command> ::= <Uses> Identifier NewLine <Const>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_USES_USES :
                //<Uses> ::= uses
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONST_NEWLINE_NEWLINE :
                //<Const> ::= <Constant> <Const_Var> NewLine <Comment> NewLine <Variable_Sec>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONST :
                //<Const> ::= <Variable_Sec>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONST_NEWLINE :
                //<Const> ::= <Constant> <Const_Var> NewLine <Variable_Sec>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONSTANT_CONST :
                //<Constant> ::= const
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONSTANT_VALUE_STRING :
                //<constant_value> ::= String
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONSTANT_VALUE_REAL :
                //<constant_value> ::= Real
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONSTANT_VALUE_INTEGER :
                //<constant_value> ::= Integer
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONSTANT_VALUE_CHAR :
                //<constant_value> ::= Char
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONSTANT_VALUE :
                //<constant_value> ::= <TF>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TF_TRUE :
                //<TF> ::= true
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TF_FALSE :
                //<TF> ::= false
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONST_VAR_COLON_SEMI :
                //<Const_Var> ::= <Arg_name> ':' <constant_value> ';' <Const_Var>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONST_VAR_COLON_SEMI2 :
                //<Const_Var> ::= <Arg_name> ':' <constant_value> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARG_NAME_IDENTIFIER :
                //<Arg_name> ::= Identifier
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE_BOOLEAN :
                //<type> ::= boolean
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE_CHARACTER :
                //<type> ::= character
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE_INT :
                //<type> ::= int
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE :
                //<type> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VARIABLE_SEC_NEWLINE :
                //<Variable_Sec> ::= <Var_Word> NewLine <Var_Dec>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VARIABLE_SEC_IDENTIFIER_NEWLINE :
                //<Variable_Sec> ::= <Proc> Identifier NewLine
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VARIABLE_SEC_NEWLINE2 :
                //<Variable_Sec> ::= <Fun_Declaration> NewLine
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VAR_DEC_COLON_SEMI_NEWLINE :
                //<Var_Dec> ::= <Var_Names> ':' <type> ';' NewLine <Var_Dec>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VAR_DEC_NEWLINE :
                //<Var_Dec> ::= <Assignment_Stmt> NewLine <Var_Dec>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VAR_DEC :
                //<Var_Dec> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VAR_WORD_VAR :
                //<Var_Word> ::= var
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VAR_NAMES_COMMA :
                //<Var_Names> ::= <Var_Names> ',' <Arg_name>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VAR_NAMES :
                //<Var_Names> ::= <Arg_name>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCTION :
                //<Function> ::= <Fun_Sec>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCTION_NEWLINE_NEWLINE_NEWLINE :
                //<Function> ::= <Fun_Sec> NewLine <Comment> NewLine <Procedure> NewLine
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCTION_NEWLINE_NEWLINE_NEWLINE_NEWLINE :
                //<Function> ::= <Fun_Sec> NewLine <Comment> NewLine <Procedure> NewLine <Comment> NewLine
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCTION_NEWLINE_NEWLINE_NEWLINE2 :
                //<Function> ::= <Fun_Sec> NewLine <Procedure> NewLine <Comment> NewLine
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCTION_NEWLINE_NEWLINE :
                //<Function> ::= <Fun_Sec> NewLine <Procedure> NewLine
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUN_SEC_NEWLINE_NEWLINE :
                //<Fun_Sec> ::= <Fun_Declaration> NewLine <Variable_Sec> NewLine <Function_Content> <Fun_Sec>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUN_SEC_NEWLINE_SEMI :
                //<Fun_Sec> ::= <Fun_Declaration> NewLine <Variable_Sec> ';' <Function_Content>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUN_DECLARATION_LPAREN_RPAREN_COLON_SEMI :
                //<Fun_Declaration> ::= <Fun> <Fun_Name> '(' <Argument_Sec> ')' ':' <type> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUN_FUNCTION :
                //<Fun> ::= function
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUN_NAME_IDENTIFIER :
                //<Fun_Name> ::= Identifier
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARGUMENT_SEC_COLON_SEMI :
                //<Argument_Sec> ::= <Arg_name> ':' <type> ';' <Argument_Sec>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARGUMENT_SEC :
                //<Argument_Sec> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCTION_CONTENT_NEWLINE_NEWLINE_NEWLINE_NEWLINE_NEWLINE_COLONEQ_NEWLINE_NEWLINE_SEMI :
                //<Function_Content> ::= <Stmt_sequence> NewLine <Begin> NewLine <Comment> NewLine <Stmt_sequence> NewLine <Comment> NewLine <Fun_Name> ':=' <Arg_name> NewLine <Comment> NewLine <End> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCTION_CONTENT_NEWLINE_NEWLINE_NEWLINE_NEWLINE_COLONEQ_NEWLINE_NEWLINE_SEMI :
                //<Function_Content> ::= <Stmt_sequence> NewLine <Begin> NewLine <Stmt_sequence> NewLine <Comment> NewLine <Fun_Name> ':=' <Arg_name> NewLine <Comment> NewLine <End> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCTION_CONTENT_NEWLINE_NEWLINE_NEWLINE_NEWLINE_COLONEQ_NEWLINE_NEWLINE_SEMI2 :
                //<Function_Content> ::= <Stmt_sequence> NewLine <Begin> NewLine <Comment> NewLine <Stmt_sequence> NewLine <Fun_Name> ':=' <Arg_name> NewLine <Comment> NewLine <End> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCTION_CONTENT_NEWLINE_NEWLINE_NEWLINE_NEWLINE_NEWLINE_COLONEQ_NEWLINE_SEMI :
                //<Function_Content> ::= <Stmt_sequence> NewLine <Begin> NewLine <Comment> NewLine <Stmt_sequence> NewLine <Comment> NewLine <Fun_Name> ':=' <Arg_name> NewLine <End> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCTION_CONTENT_NEWLINE_NEWLINE_NEWLINE_COLONEQ_NEWLINE_NEWLINE_SEMI :
                //<Function_Content> ::= <Stmt_sequence> NewLine <Begin> NewLine <Stmt_sequence> NewLine <Fun_Name> ':=' <Arg_name> NewLine <Comment> NewLine <End> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCTION_CONTENT_NEWLINE_NEWLINE_NEWLINE_COLONEQ_NEWLINE_SEMI :
                //<Function_Content> ::= <Stmt_sequence> NewLine <Begin> NewLine <Stmt_sequence> NewLine <Fun_Name> ':=' <Arg_name> NewLine <End> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCTION_CONTENT_NEWLINE_NEWLINE_NEWLINE_NEWLINE_COLONEQ_NEWLINE_SEMI :
                //<Function_Content> ::= <Stmt_sequence> NewLine <Begin> NewLine <Comment> NewLine <Stmt_sequence> NewLine <Fun_Name> ':=' <Arg_name> NewLine <End> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT_SEQUENCE :
                //<Stmt_sequence> ::= <Stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT_SEQUENCE_NEWLINE_NEWLINE_NEWLINE :
                //<Stmt_sequence> ::= <Stmt> NewLine <Comment> NewLine <Stmt_sequence> NewLine
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT_SEQUENCE_NEWLINE_NEWLINE :
                //<Stmt_sequence> ::= <Stmt> NewLine <Stmt_sequence> NewLine
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT :
                //<Stmt> ::= <Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT2 :
                //<Stmt> ::= <Assignment_Stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT3 :
                //<Stmt> ::= <IF_Statment>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT4 :
                //<Stmt> ::= <For_Stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT5 :
                //<Stmt> ::= <Repeat_Stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT6 :
                //<Stmt> ::= <While_stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT7 :
                //<Stmt> ::= <Break>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT8 :
                //<Stmt> ::= <Continue>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT9 :
                //<Stmt> ::= <Go_To>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT10 :
                //<Stmt> ::= <Send_To>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT11 :
                //<Stmt> ::= <Read_Line>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT12 :
                //<Stmt> ::= <Write_Line>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT13 :
                //<Stmt> ::= <Read>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT14 :
                //<Stmt> ::= <Write>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT15 :
                //<Stmt> ::= <Call_Fun>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT_NEWLINE :
                //<Stmt> ::= NewLine
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_BREAK_SEMI :
                //<Break> ::= <Br> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_BR_BREAK :
                //<Br> ::= Break
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONTINUE_SEMI :
                //<Continue> ::= <Con> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CON_CONTINUE :
                //<Con> ::= Continue
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_GO_TO_SEMI :
                //<Go_To> ::= <Go> <Send_To> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_GO_GOTO :
                //<Go> ::= GoTo
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SEND_TO_COLON :
                //<Send_To> ::= <Label_go> ':' <Label_Stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LABEL_GO_LABEL :
                //<Label_go> ::= Label
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LABEL_STMT_IDENTIFIER :
                //<Label_Stmt> ::= Identifier
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LABEL_STMT_CHAR :
                //<Label_Stmt> ::= Char
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LABEL_STMT_REAL :
                //<Label_Stmt> ::= Real
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LABEL_STMT_INTEGER :
                //<Label_Stmt> ::= Integer
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_REP_REPEAT :
                //<Rep> ::= Repeat
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_UNTILL_UNTILL :
                //<Untill> ::= Untill
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_REPEAT_STMT_NEWLINE_NEWLINE_NEWLINE_SEMI :
                //<Repeat_Stmt> ::= <Rep> NewLine <Comment> NewLine <Stmt_sequence> NewLine <Untill> <Condition> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_REPEAT_STMT_NEWLINE_NEWLINE_NEWLINE_SEMI2 :
                //<Repeat_Stmt> ::= <Rep> NewLine <Stmt_sequence> NewLine <Comment> NewLine <Untill> <Condition> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_REPEAT_STMT_NEWLINE_NEWLINE_SEMI :
                //<Repeat_Stmt> ::= <Rep> NewLine <Stmt_sequence> NewLine <Untill> <Condition> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONDITION :
                //<Condition> ::= <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONDITION2 :
                //<Condition> ::= <Expression> <OP> <Condition>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_GT :
                //<Expression> ::= <Expression> '>' <Add Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_LT :
                //<Expression> ::= <Expression> '<' <Add Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_LTEQ :
                //<Expression> ::= <Expression> '<=' <Add Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_GTEQ :
                //<Expression> ::= <Expression> '>=' <Add Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_EQ :
                //<Expression> ::= <Expression> '=' <Add Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_LTGT :
                //<Expression> ::= <Expression> '<>' <Add Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION :
                //<Expression> ::= <Add Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION2 :
                //<Expression> ::= <TF>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_AMP :
                //<OP> ::= '&'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_PIPE :
                //<OP> ::= '|'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ADDEXP_PLUS :
                //<Add Exp> ::= <Add Exp> '+' <MultExp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ADDEXP_MINUS :
                //<Add Exp> ::= <Add Exp> '-' <MultExp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ADDEXP :
                //<Add Exp> ::= <MultExp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MULTEXP_TIMES :
                //<MultExp> ::= <MultExp> '*' <Negate Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MULTEXP_DIV :
                //<MultExp> ::= <MultExp> '/' <Negate Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MULTEXP :
                //<MultExp> ::= <Negate Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NEGATEEXP_MINUS :
                //<Negate Exp> ::= '-' <Value>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NEGATEEXP :
                //<Negate Exp> ::= <Value>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUE_IDENTIFIER :
                //<Value> ::= Identifier
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUE_FLOAT :
                //<Value> ::= Float
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUE_INTEGER :
                //<Value> ::= Integer
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUE_LPAREN_RPAREN :
                //<Value> ::= '(' <Add Exp> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FOR_STMT_IDENTIFIER_COLONEQ_INTEGER_INTEGER_NEWLINE_NEWLINE_NEWLINE_NEWLINE_NEWLINE_SEMI :
                //<For_Stmt> ::= <For> Identifier ':=' Integer <To> Integer <Do> NewLine <Comment> NewLine <Begin> NewLine <Comment> NewLine <Stmt_sequence> NewLine <Comment> <End> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FOR_STMT_IDENTIFIER_COLONEQ_INTEGER_INTEGER_NEWLINE_NEWLINE_NEWLINE_NEWLINE_SEMI :
                //<For_Stmt> ::= <For> Identifier ':=' Integer <To> Integer <Do> NewLine <Begin> NewLine <Comment> NewLine <Stmt_sequence> NewLine <Comment> <End> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FOR_STMT_IDENTIFIER_COLONEQ_INTEGER_INTEGER_NEWLINE_NEWLINE_NEWLINE_SEMI :
                //<For_Stmt> ::= <For> Identifier ':=' Integer <To> Integer <Do> NewLine <Begin> NewLine <Stmt_sequence> NewLine <Comment> <End> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FOR_STMT_IDENTIFIER_COLONEQ_INTEGER_INTEGER_NEWLINE_NEWLINE_NEWLINE_NEWLINE_SEMI2 :
                //<For_Stmt> ::= <For> Identifier ':=' Integer <To> Integer <Do> NewLine <Comment> NewLine <Begin> NewLine <Stmt_sequence> NewLine <Comment> <End> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FOR_STMT_IDENTIFIER_COLONEQ_INTEGER_INTEGER_NEWLINE_NEWLINE_NEWLINE_SEMI2 :
                //<For_Stmt> ::= <For> Identifier ':=' Integer <To> Integer <Do> NewLine <Comment> NewLine <Begin> NewLine <Stmt_sequence> <End> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FOR_STMT_IDENTIFIER_COLONEQ_INTEGER_INTEGER_NEWLINE_NEWLINE_NEWLINE_SEMI3 :
                //<For_Stmt> ::= <For> Identifier ':=' Integer <To> Integer <Do> NewLine <Begin> NewLine <Stmt_sequence> NewLine <End> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FOR_FOR :
                //<For> ::= For
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DO_DO :
                //<Do> ::= DO
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TO_TO :
                //<To> ::= TO
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TO_DOWNTO :
                //<To> ::= 'Down To'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_BEGIN_BEGIN :
                //<Begin> ::= begin
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_END_END :
                //<End> ::= END
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP :
                //<Exp> ::= <Exp> <Addop> <Term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP2 :
                //<Exp> ::= <Term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ADDOP_PLUS :
                //<Addop> ::= '+'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ADDOP_MINUS :
                //<Addop> ::= '-'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM :
                //<Term> ::= <Term> <Mulop> <Factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM2 :
                //<Term> ::= <Factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MULOP_TIMES :
                //<Mulop> ::= '*'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MULOP_DIV :
                //<Mulop> ::= '/'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_LPAREN_RPAREN :
                //<Factor> ::= '(' <Exp> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_SEMI :
                //<Factor> ::= <Values> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR :
                //<Factor> ::= <Boolean_Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUES_REAL :
                //<Values> ::= Real
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUES_INTEGER :
                //<Values> ::= Integer
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUES_IDENTIFIER :
                //<Values> ::= Identifier
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUES_CHAR :
                //<Values> ::= Char
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUES_STRING :
                //<Values> ::= String
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGNMENT_STMT_COLONEQ :
                //<Assignment_Stmt> ::= <Arg_name> ':=' <Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGNMENT_STMT_COLONEQ2 :
                //<Assignment_Stmt> ::= <Arg_name> ':=' <Call_Fun>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGNMENT_STMT_COLONEQ3 :
                //<Assignment_Stmt> ::= <Arg_name> ':=' <Read>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGNMENT_STMT_COLONEQ4 :
                //<Assignment_Stmt> ::= <Arg_name> ':=' <Read_Line>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CALL_FUN_LPAREN_RPAREN_SEMI :
                //<Call_Fun> ::= <Fun_Name> '(' <Var_Names> ')' ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_BOOLEAN_EXPRESSION_LPAREN_RPAREN_SEMI :
                //<Boolean_Expression> ::= '(' <Arg_name> <And> <Arg_name> ')' ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_BOOLEAN_EXPRESSION_LPAREN_RPAREN_SEMI2 :
                //<Boolean_Expression> ::= '(' <Arg_name> <Or> <Arg_name> ')' ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_BOOLEAN_EXPRESSION_LPAREN_RPAREN_SEMI3 :
                //<Boolean_Expression> ::= '(' <Arg_name> <Not> <Arg_name> ')' ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_BOOLEAN_EXPRESSION_LPAREN_RPAREN :
                //<Boolean_Expression> ::= '(' <Boolean_Expression> <And> <Boolean_Expression> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_BOOLEAN_EXPRESSION_LPAREN_RPAREN2 :
                //<Boolean_Expression> ::= '(' <Boolean_Expression> <Or> <Boolean_Expression> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_BOOLEAN_EXPRESSION_LPAREN_RPAREN3 :
                //<Boolean_Expression> ::= '(' <Boolean_Expression> <Not> <Boolean_Expression> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_AND_AND :
                //<And> ::= and
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OR_OR :
                //<Or> ::= or
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NOT_NOT :
                //<Not> ::= Not
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_IF :
                //<If> ::= if
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ELSE_ELSE :
                //<Else> ::= else
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_THEN_THEN :
                //<Then> ::= THEN
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_STATMENT_LPAREN_RPAREN :
                //<IF_Statment> ::= <If> '(' <Condition> ')' <Then> <Stmt_sequence>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_STATMENT_LPAREN_RPAREN_NEWLINE_NEWLINE :
                //<IF_Statment> ::= <If> '(' <Condition> ')' <Then> NewLine <Comment> NewLine <Stmt_sequence>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_STATMENT_LPAREN_RPAREN_NEWLINE_NEWLINE_NEWLINE :
                //<IF_Statment> ::= <If> '(' <Condition> ')' <Then> NewLine <Stmt_sequence> NewLine <Else> NewLine <Stmt_sequence>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_STATMENT_LPAREN_RPAREN_NEWLINE_NEWLINE_NEWLINE_NEWLINE_NEWLINE_NEWLINE_NEWLINE :
                //<IF_Statment> ::= <If> '(' <Condition> ')' <Then> NewLine <Comment> NewLine <Stmt_sequence> NewLine <Comment> NewLine <Else> NewLine <Comment> NewLine <Stmt_sequence> NewLine <Comment>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_STATMENT_LPAREN_RPAREN_NEWLINE_NEWLINE_NEWLINE_NEWLINE_NEWLINE_NEWLINE :
                //<IF_Statment> ::= <If> '(' <Condition> ')' <Then> NewLine <Stmt_sequence> NewLine <Comment> NewLine <Else> NewLine <Comment> NewLine <Stmt_sequence> NewLine <Comment>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_STATMENT_LPAREN_RPAREN_NEWLINE_NEWLINE_NEWLINE_NEWLINE_NEWLINE_NEWLINE2 :
                //<IF_Statment> ::= <If> '(' <Condition> ')' <Then> NewLine <Comment> NewLine <Stmt_sequence> NewLine <Else> NewLine <Comment> NewLine <Stmt_sequence> NewLine <Comment>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_STATMENT_LPAREN_RPAREN_NEWLINE_NEWLINE_NEWLINE_NEWLINE_NEWLINE_NEWLINE3 :
                //<IF_Statment> ::= <If> '(' <Condition> ')' <Then> NewLine <Comment> NewLine <Stmt_sequence> NewLine <Comment> NewLine <Else> NewLine <Stmt_sequence> NewLine <Comment>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_STATMENT_LPAREN_RPAREN_NEWLINE_NEWLINE_NEWLINE_NEWLINE_NEWLINE_NEWLINE4 :
                //<IF_Statment> ::= <If> '(' <Condition> ')' <Then> NewLine <Comment> NewLine <Stmt_sequence> NewLine <Comment> NewLine <Else> NewLine <Comment> NewLine <Stmt_sequence>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_STATMENT_LPAREN_RPAREN_NEWLINE_NEWLINE_NEWLINE_NEWLINE_NEWLINE :
                //<IF_Statment> ::= <If> '(' <Condition> ')' <Then> NewLine <Stmt_sequence> NewLine <Comment> NewLine <Else> NewLine <Comment> NewLine <Stmt_sequence>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_STATMENT_LPAREN_RPAREN_NEWLINE_NEWLINE_NEWLINE_NEWLINE_NEWLINE2 :
                //<IF_Statment> ::= <If> '(' <Condition> ')' <Then> NewLine <Comment> NewLine <Stmt_sequence> NewLine <Else> NewLine <Comment> NewLine <Stmt_sequence>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_STATMENT_LPAREN_RPAREN_NEWLINE_NEWLINE_NEWLINE_NEWLINE_NEWLINE3 :
                //<IF_Statment> ::= <If> '(' <Condition> ')' <Then> NewLine <Comment> NewLine <Stmt_sequence> NewLine <Comment> NewLine <Else> NewLine <Stmt_sequence>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_STATMENT_LPAREN_RPAREN_NEWLINE_NEWLINE_NEWLINE_NEWLINE_NEWLINE4 :
                //<IF_Statment> ::= <If> '(' <Condition> ')' <Then> NewLine <Stmt_sequence> NewLine <Comment> NewLine <Else> NewLine <Stmt_sequence> NewLine <Comment>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_STATMENT_LPAREN_RPAREN_NEWLINE_NEWLINE_NEWLINE_NEWLINE_NEWLINE5 :
                //<IF_Statment> ::= <If> '(' <Condition> ')' <Then> NewLine <Comment> NewLine <Stmt_sequence> NewLine <Else> NewLine <Stmt_sequence> NewLine <Comment>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_STATMENT_LPAREN_RPAREN_NEWLINE_NEWLINE_NEWLINE_NEWLINE_NEWLINE6 :
                //<IF_Statment> ::= <If> '(' <Condition> ')' <Then> NewLine <Stmt_sequence> NewLine <Else> NewLine <Comment> NewLine <Stmt_sequence> NewLine <Comment>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WHILE_STMT_NEWLINE_NEWLINE_NEWLINE_SEMI :
                //<While_stmt> ::= <While> <Condition> <Do> NewLine <Begin> NewLine <Stmt_sequence> NewLine <End> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WHILE_STMT_NEWLINE_NEWLINE_NEWLINE_NEWLINE_NEWLINE_SEMI :
                //<While_stmt> ::= <While> <Condition> <Do> NewLine <Comment> NewLine <Begin> NewLine <Stmt_sequence> NewLine <Comment> NewLine <End> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WHILE_STMT_NEWLINE_NEWLINE_NEWLINE_NEWLINE_NEWLINE_NEWLINE_SEMI :
                //<While_stmt> ::= <While> <Condition> <Do> NewLine <Comment> NewLine <Begin> NewLine <Comment> NewLine <Stmt_sequence> NewLine <Comment> NewLine <End> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WHILE_STMT_NEWLINE_NEWLINE_NEWLINE_NEWLINE_NEWLINE_SEMI2 :
                //<While_stmt> ::= <While> <Condition> <Do> NewLine <Begin> NewLine <Comment> NewLine <Stmt_sequence> NewLine <Comment> NewLine <End> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WHILE_STMT_NEWLINE_NEWLINE_NEWLINE_NEWLINE_SEMI :
                //<While_stmt> ::= <While> <Condition> <Do> NewLine <Comment> NewLine <Begin> NewLine <Stmt_sequence> NewLine <End> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WHILE_STMT_NEWLINE_NEWLINE_NEWLINE_NEWLINE_NEWLINE_SEMI3 :
                //<While_stmt> ::= <While> <Condition> <Do> NewLine <Comment> NewLine <Begin> NewLine <Comment> NewLine <Stmt_sequence> NewLine <End> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WHILE_STMT_NEWLINE_NEWLINE_NEWLINE_NEWLINE_SEMI2 :
                //<While_stmt> ::= <While> <Condition> <Do> NewLine <Begin> NewLine <Comment> NewLine <Stmt_sequence> NewLine <End> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WHILE_WHILE :
                //<While> ::= While
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WORDREAD_READ :
                //<WordRead> ::= read
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WORDREADLINE_READLN :
                //<WordReadLine> ::= readln
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SYNTAXREAD_COMMA :
                //<syntaxread> ::= <syntaxread> ',' <Arg_name>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SYNTAXREAD :
                //<syntaxread> ::= <Arg_name>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_READ_LPAREN_RPAREN_SEMI :
                //<Read> ::= <WordRead> '(' <syntaxread> ')' ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_READ_SEMI :
                //<Read> ::= <WordRead> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_READ_LPAREN_RPAREN :
                //<Read> ::= <WordRead> '(' <syntaxread> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_READ :
                //<Read> ::= <WordRead>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_READ_LINE_LPAREN_RPAREN_SEMI :
                //<Read_Line> ::= <WordReadLine> '(' <syntaxread> ')' ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_READ_LINE_SEMI :
                //<Read_Line> ::= <WordReadLine> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_READ_LINE_LPAREN_RPAREN :
                //<Read_Line> ::= <WordReadLine> '(' <syntaxread> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_READ_LINE :
                //<Read_Line> ::= <WordReadLine>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WORDWRITE_WRITE :
                //<WordWrite> ::= write
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WORDWRITELINE_WRITELN :
                //<WordWriteLine> ::= writeln
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SYNTAXWRITE_COMMA :
                //<syntaxwrite> ::= <syntaxwrite> ',' <syntaxwrite>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SYNTAXWRITE_STRING :
                //<syntaxwrite> ::= String
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SYNTAXWRITE :
                //<syntaxwrite> ::= <Arg_name>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WRITE_LPAREN_RPAREN_SEMI :
                //<Write> ::= <WordWrite> '(' <syntaxwrite> ')' ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WRITE_SEMI :
                //<Write> ::= <WordWrite> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WRITE_LPAREN_RPAREN :
                //<Write> ::= <WordWrite> '(' <syntaxwrite> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WRITE :
                //<Write> ::= <WordWrite>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WRITE_LINE_LPAREN_RPAREN_SEMI :
                //<Write_Line> ::= <WordWriteLine> '(' <syntaxwrite> ')' ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WRITE_LINE_SEMI :
                //<Write_Line> ::= <WordWriteLine> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WRITE_LINE_LPAREN_RPAREN :
                //<Write_Line> ::= <WordWriteLine> '(' <syntaxwrite> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WRITE_LINE :
                //<Write_Line> ::= <WordWriteLine>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PROCEDURE_NEWLINE :
                //<Procedure> ::= <Proc_Sec> NewLine
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PROCEDURE_NEWLINE_NEWLINE_NEWLINE :
                //<Procedure> ::= <Proc_Sec> NewLine <Comment> NewLine <Function> NewLine <Comment>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PROCEDURE_NEWLINE_NEWLINE :
                //<Procedure> ::= <Proc_Sec> NewLine <Comment> NewLine <Function>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PROCEDURE_NEWLINE_NEWLINE2 :
                //<Procedure> ::= <Proc_Sec> NewLine <Function> NewLine <Comment>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PROC_SEC_IDENTIFIER_NEWLINE :
                //<Proc_Sec> ::= <Proc> Identifier <Proc_ArgDec> NewLine <Proc_Content>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PROC_ARGDEC_NEWLINE :
                //<Proc_ArgDec> ::= <Variable_Sec> NewLine <Proc_ArgDec>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PROC_ARGDEC_NEWLINE2 :
                //<Proc_ArgDec> ::= <Fun_Declaration> NewLine <Proc_ArgDec>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PROC_ARGDEC :
                //<Proc_ArgDec> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PROC_PROCEDURE :
                //<Proc> ::= Procedure
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PROC_CONTENT_NEWLINE_NEWLINE_NEWLINE_NEWLINE_NEWLINE_SEMI :
                //<Proc_Content> ::= <Stmt_sequence> <Comment> NewLine <Begin> NewLine <Comment> NewLine <Stmt_sequence> NewLine <Comment> NewLine <End> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PROC_CONTENT_NEWLINE_NEWLINE_NEWLINE_SEMI :
                //<Proc_Content> ::= <Stmt_sequence> <Comment> NewLine <Begin> NewLine <Stmt_sequence> NewLine <End> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PROC_CONTENT_NEWLINE_NEWLINE_NEWLINE_SEMI2 :
                //<Proc_Content> ::= <Stmt_sequence> <Begin> NewLine <Comment> NewLine <Stmt_sequence> NewLine <End> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PROC_CONTENT_NEWLINE_NEWLINE_NEWLINE_SEMI3 :
                //<Proc_Content> ::= <Stmt_sequence> <Begin> NewLine <Stmt_sequence> NewLine <Comment> NewLine <End> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PROC_CONTENT_NEWLINE_NEWLINE_NEWLINE_NEWLINE_SEMI :
                //<Proc_Content> ::= <Stmt_sequence> <Comment> NewLine <Begin> NewLine <Comment> NewLine <Stmt_sequence> NewLine <End> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PROC_CONTENT_NEWLINE_NEWLINE_NEWLINE_NEWLINE_SEMI2 :
                //<Proc_Content> ::= <Stmt_sequence> <Begin> NewLine <Comment> NewLine <Stmt_sequence> NewLine <Comment> NewLine <End> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PROC_CONTENT_NEWLINE_NEWLINE_NEWLINE_NEWLINE_SEMI3 :
                //<Proc_Content> ::= <Stmt_sequence> <Comment> NewLine <Begin> NewLine <Stmt_sequence> NewLine <Comment> NewLine <End> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MAIN_BLOCK_NEWLINE_NEWLINE_NEWLINE_NEWLINE :
                //<Main_Block> ::= <Begin> NewLine <Comment> NewLine <Stmt_sequence> NewLine <Comment> NewLine <End_Main>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MAIN_BLOCK_NEWLINE_NEWLINE_NEWLINE :
                //<Main_Block> ::= <Begin> NewLine <Stmt_sequence> NewLine <Comment> NewLine <End_Main>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MAIN_BLOCK_NEWLINE_NEWLINE_NEWLINE2 :
                //<Main_Block> ::= <Begin> NewLine <Comment> NewLine <Stmt_sequence> NewLine <End_Main>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_END_MAIN_ENDDOT :
                //<End_Main> ::= 'end.'
                //todo: Create a new object using the stored tokens.
                return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
           
            string message = "Token error with input: '" + args.Token.ToString() + "'  " +  "In Line " + args.Token.Location.LineNr;
            //if (args.Token.ToString().CompareTo("") == )
            //{
                Errors.Items.Add(message);
            //}
           
           
            //todo: Report message to UI?
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message = "Parse error caused by token: '" + args.UnexpectedToken.ToString() + "'" + " In Line " + args.UnexpectedToken.Location.LineNr;
     
            Errors.Items.Add(message);
            string message2 = "Expected Token: '" + args.ExpectedTokens.ToString() + "'";

            Errors.Items.Add(message2);
       
        }


    }
}
